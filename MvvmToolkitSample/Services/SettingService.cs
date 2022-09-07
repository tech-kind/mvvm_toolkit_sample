using MvvmToolkitSample.Core.Services;
using Windows.Foundation.Collections;
using Windows.Storage;

#nullable enable

namespace MvvmToolkitSample.Services
{
    public sealed class SettingService : ISettingService
    {
        private readonly IPropertySet _settingStorage = ApplicationData.Current.LocalSettings.Values;

        public T? GetValue<T>(string key)
        {
            if (_settingStorage.TryGetValue(key, out object? value))
            {
                return (T)value!;
            }

            return default;
        }

        public void SetValue<T>(string key, T? value)
        {
            if (!_settingStorage.ContainsKey(key)) _settingStorage.Add(key, value);
            else _settingStorage[key] = value;
        }
    }
}
