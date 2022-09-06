using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public class ObservableObjectPageViewModel : SamplePageViewModel
    {
        public ObservableObjectPageViewModel(IFileService fileService)
            : base(fileService)
        {
            ReloadTaskCommand = new RelayCommand(ReloadTask);
        }

        public ICommand ReloadTaskCommand { get; }

        private string? _name;

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private TaskNotifier? _myTask;

        public Task? MyTask
        {
            get => _myTask;
            private set => SetPropertyAndNotifyOnCompletion(ref _myTask, value);
        }

        public void ReloadTask()
        {
            MyTask = Task.Delay(3000);
        }
    }
}
