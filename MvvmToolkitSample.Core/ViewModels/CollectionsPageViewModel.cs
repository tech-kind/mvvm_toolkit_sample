using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public partial class CollectionsPageViewModel : SamplePageViewModel
    {
        public CollectionsPageViewModel(IFileService fileService)
            : base(fileService)
        {

        }
    }
}
