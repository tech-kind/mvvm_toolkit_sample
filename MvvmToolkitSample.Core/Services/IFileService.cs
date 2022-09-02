using System.IO;
using System.Threading.Tasks;

namespace MvvmToolkitSample.Core.Services
{
    public interface IFileService
    {
        string InstallationPath { get; }

        Task<Stream> OpenForReadAsync(string path);
    }
}
