using System.Threading.Tasks;

namespace MvvmToolkitSample.ViewModels;

public interface ILoadable
{
    Task LoadAsync();
}
