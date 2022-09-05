using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Services;
using MvvmToolkitSample.Core.Helpers;

namespace MvvmToolkitSample.Core.ViewModels
{
    public class SamplePageViewModel : ObservableObject
    {
        private readonly IFileService _fileService;

        public SamplePageViewModel(IFileService fileService)
        {
            _fileService = fileService;

            LoadDocsCommand = new AsyncRelayCommand<string>(LoadDocsAsync);
        }

        public IAsyncRelayCommand<string> LoadDocsCommand { get; }

        private IReadOnlyDictionary<string, string> _texts;

        public IReadOnlyDictionary<string, string> Texts
        {
            get => _texts;
            set => SetProperty(ref _texts, value);
        }

        public string GetParagraph(string key)
        {
            return Texts is not null && Texts.TryGetValue(key, out var value) ? value : string.Empty;
        }

        private async Task LoadDocsAsync(string? name)
        {
            if (name is null) return;

            if (LoadDocsCommand.ExecutionTask is not null) return;

            string directory = Path.GetDirectoryName(name);
            string fileName = Path.GetFileName(name);
            string path = Path.Combine("Assets", "docs", directory, $"{fileName}.md");
            using Stream stream = await _fileService.OpenForReadAsync(path);
            using StreamReader reader = new(stream);
            string text = await reader.ReadToEndAsync();

            string fixedText = Regex.Replace(text, @"!\[[^\]]+\]\(([^ \)]+)(?:[^\)]+)?\)", m => $"![]({m.Groups[1].Value})");

            Texts = MarkdownHelper.GetParagraphs(fixedText);

            OnPropertyChanged(nameof(GetParagraph));
        }
    }
}
