﻿using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MvvmToolkitSample.Models;
using MvvmToolkitSample.Models.Extensions;
using MvvmToolkitSample.Services;
using MvvmToolkitSample.ViewModels.Messages;

namespace MvvmToolkitSample.ViewModels;

public class CustomerViewModel : ViewModelBase
{
    private readonly IDataService<Customer> _dataService;
    private Customer? _customer;

    public CustomerViewModel(IDataService<Customer> dataService)
    {
        _dataService = dataService ??
            throw new ArgumentNullException(nameof(dataService));

        AddCmd = new RelayCommand(OnAdd, () => CanAdd);
        SaveCmd = new RelayCommand(OnSave, () => CanSave);
    }

    public Customer? SelectedItem
    {
        get => _customer;
        set
        {
            if (value is null && SelectedItem is not null)
            {
                SelectedItem.PropertyChanged -= OnSelectedItemPropertyChanged;
            }
            if (SetProperty(ref _customer, value))
            {
                OnPropertyChanged(nameof(IsItemSelected));
                if (SelectedItem is not null)
                {
                    SelectedItem.PropertyChanged += OnSelectedItemPropertyChanged;
                }
            }
        }
    }

    public bool IsItemSelected => SelectedItem != null;

    public IRelayCommand AddCmd { get; }

    public IRelayCommand SaveCmd { get; }

    public bool CanAdd => CanExecute;

    public bool CanSave => CanExecute && IsValidCustomer;

    private bool IsValidCustomer => SelectedItem.IsValid();

    private async void OnAdd()
    {
        SelectedItem = await _dataService.CreateAsync();
    }

    private async void OnSave()
    {
        if (SelectedItem is not null)
        {
            if (SelectedItem.IsNullOrNew())
            {
                await _dataService.InsertAsync(SelectedItem);
            }
            else
            {
                await _dataService.UpdateAsync(SelectedItem);
            }
            WeakReferenceMessenger.Default.Send(new CustomerSavedMessage(SelectedItem));
        }
    }

    private void OnSelectedItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Customer.FirstName) ||
            e.PropertyName == nameof(Customer.LastName))
        {
            SaveCmd.NotifyCanExecuteChanged();
        }
    }
}
