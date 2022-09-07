using System;
using System.Threading.Tasks;
using MvvmToolkitSample.Core.Services;
using Windows.UI.Xaml.Controls;


#nullable enable

namespace MvvmToolkitSample.Services
{
    public sealed class DialogService : IDialogService
    {
        public Task ShowMessageDialogAsync(string title, string message)
        {
            ContentDialog dialog = new();
            dialog.Title = title;
            dialog.CloseButtonText = "Close";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = message;

            return dialog.ShowAsync().AsTask();
        }
    }
}
