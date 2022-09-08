using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MvvmToolkitSample.Models;
using MvvmToolkitSample.Services;
using MvvmToolkitSample.ViewModels.Messages;

namespace MvvmToolkitSample.ViewModels;

public class CustomersViewModel : ViewModelBase, ILoadable
{
    private readonly IDataService<Customer> _dataService;
    private IList<Customer> _index;

    public CustomersViewModel(IDataService<Customer> dataService)
    {
        _dataService = dataService ??
            throw new ArgumentNullException(nameof(dataService));

        _index = new List<Customer>();

        WeakReferenceMessenger.Default.Register<CustomerSavedMessage>(
            this, (r, m) => OnCustomerSaved(m));
    }

    public async Task LoadAsync()
    {
        Index = await _dataService.IndexAsync();
    }

    public async void OnCustomerSaved(CustomerSavedMessage m)
    {
        await LoadAsync();
    }

    public IList<Customer> Index
    {
        get => _index;
        set => SetProperty(ref _index, value);
    }
}
