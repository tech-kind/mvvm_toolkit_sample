using System.Threading.Tasks;

namespace MvvmToolkitSample.Core.Services
{
    public interface IDialogService
    {
        Task ShowMessageDialogAsync(string title, string message);
    }
}
