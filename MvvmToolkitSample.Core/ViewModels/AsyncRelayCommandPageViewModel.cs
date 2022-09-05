using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public class AsyncRelayCommandPageViewModel : SamplePageViewModel
    {
        public AsyncRelayCommandPageViewModel(IFileService fileService)
            : base(fileService)
        {
            DownloadTextCommand = new AsyncRelayCommand(DownloadTextAsync);
        }

        public IAsyncRelayCommand DownloadTextCommand { get; }

        private async Task<string> DownloadTextAsync()
        {
            // simulate web request
            await Task.Delay(3000);

            return "Hello world!";
        }
    }
}
