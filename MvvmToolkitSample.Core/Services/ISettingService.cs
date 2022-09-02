using System;

namespace MvvmToolkitSample.Core.Services
{
    public interface ISettingService
    {
        void SetValue<T>(string key, T? value);

        T? GetValue<T>(string key);
    }
}
