using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public partial class ObservableValidatorPageViewModel : SamplePageViewModel
    {
        public ObservableValidatorPageViewModel(IFileService fileService)
            : base(fileService)
        {

        }
    }
}
