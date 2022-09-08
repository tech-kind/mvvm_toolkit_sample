using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmToolkitSample.Models;

public abstract class ModelBase : ObservableObject, IModel
{
    private int _id;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
}
