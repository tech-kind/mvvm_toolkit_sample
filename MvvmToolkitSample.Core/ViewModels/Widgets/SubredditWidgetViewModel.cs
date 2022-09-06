using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Models;
using MvvmToolkitSample.Core.Services;
using Nito.AsyncEx;

namespace MvvmToolkitSample.Core.ViewModels.Widgets
{
    public sealed class SubredditWidgetViewModel : ObservableRecipient
    {
        private readonly IRedditService _redditService;

        private readonly ISettingService _settingService;

        private readonly AsyncLock LoadingLock = new();

        public SubredditWidgetViewModel(IRedditService redditService, ISettingService settingService)
        {
            _redditService = redditService;
            _settingService = settingService;

            LoadPostsCommand = new AsyncRelayCommand(LoadPostsAsync);

            SelectedSubreddit = _settingService.GetValue<string>(nameof(SelectedSubreddit)) ?? SubReddits[0];
        }

        public IAsyncRelayCommand LoadPostsCommand { get; }

        public ObservableCollection<Post> Posts { get; } = new();

        public IReadOnlyList<string> SubReddits { get; } = new[]
        {
            "microsoft",
            "windows",
            "surface",
            "windowsphone",
            "dotnet",
            "csharp"
        };

        private string _selectedSubreddit;

        public string SelectedSubreddit
        {
            get => _selectedSubreddit;
            set
            {
                SetProperty(ref _selectedSubreddit, value);

                _settingService.SetValue(nameof(SelectedSubreddit), value);
            }
        }

        private Post? _selectedPost;

        public Post? SelectedPost
        {
            get => _selectedPost;
            set => SetProperty(ref _selectedPost, value, true);
        }

        private async Task LoadPostsAsync()
        {
            using (await LoadingLock.LockAsync())
            {
                try
                {
                    var response = await _redditService.GetSubredditPostsAsync(SelectedSubreddit);

                    Posts.Clear();

                    foreach(var item in response.Data!.Items!)
                    {
                        Posts.Add(item.Data!);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
