using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmToolkitSample.ViewModels;

public abstract class ViewModelBase : ObservableRecipient
{
    public bool IsBusy => false;

    public bool CanExecute => !IsBusy;
}
