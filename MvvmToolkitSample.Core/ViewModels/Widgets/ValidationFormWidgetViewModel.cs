using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels.Widgets
{
    public partial class ValidationFormWidgetViewModel : ObservableValidator
    {
        private readonly IDialogService _dialogService;

        public ValidationFormWidgetViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public event EventHandler? FormSubmissionCompleted;
        public event EventHandler? FormSubmissionFailed;

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        private string? _firstName;

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        private string? _lastName;

        [ObservableProperty]
        [Required]
        [EmailAddress]
        private string? _email;

        [ObservableProperty]
        [Required]
        [Phone]
        private string? _phoneNumber;

        [RelayCommand]
        private void Submit()
        {
            ValidateAllProperties();

            if (HasErrors)
            {
                FormSubmissionFailed?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                FormSubmissionCompleted?.Invoke(this, EventArgs.Empty);
            }
        }

        [RelayCommand]
        private void ShowErrors()
        {
            string message = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));

            _ = _dialogService.ShowMessageDialogAsync("Validation errors", message);
        }
    }
}
