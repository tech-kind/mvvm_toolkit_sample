using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public class RelayCommandPageViewModel : SamplePageViewModel
    {
        public RelayCommandPageViewModel(IFileService fileService)
            : base(fileService)
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
        }

        public ICommand IncrementCounterCommand { get; }

        private int _counter;

        public int Counter
        {
            get => _counter;
            private set => SetProperty(ref _counter, value);
        }

        private void IncrementCounter() => Counter++;
    }
}
