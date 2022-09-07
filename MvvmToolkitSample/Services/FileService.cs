using MvvmToolkitSample.Core.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

#nullable enable

namespace MvvmToolkitSample.Services
{
    public sealed class FileService : IFileService
    {
        public string InstallationPath => Package.Current.InstalledLocation.Path;

        public async Task<Stream> OpenForReadAsync(string path)
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync(Path.Combine(InstallationPath, path));

            return await file.OpenStreamForReadAsync();
        }
    }
}
