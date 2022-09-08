using CommunityToolkit.Mvvm.Messaging.Messages;
using MvvmToolkitSample.Models;

namespace MvvmToolkitSample.ViewModels.Messages;

public class CustomerSavedMessage : ValueChangedMessage<Customer>
{
    public CustomerSavedMessage(Customer value)
        : base(value)
    {

    }
}
