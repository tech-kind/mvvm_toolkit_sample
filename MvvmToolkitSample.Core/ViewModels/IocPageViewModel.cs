using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public class IocPageViewModel : SamplePageViewModel
    {
        public IocPageViewModel(IFileService fileService)
            : base(fileService)
        {

        }
    }
}
