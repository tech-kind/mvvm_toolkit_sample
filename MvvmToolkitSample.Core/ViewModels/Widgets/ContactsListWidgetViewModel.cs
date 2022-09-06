using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitSample.Core.Models;
using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels.Widgets
{
    public partial class ContactsListWidgetViewModel : ObservableObject
    {
        private readonly IContactsService _contactsService;

        public ContactsListWidgetViewModel(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public ObservableGroupedCollection<string, Contact> Contacts { get; private set; } = new();

        [RelayCommand(FlowExceptionsToTaskScheduler = true)]
        private async Task LoadContactsAsync()
        {
            ContactsQueryResponse contacts = await _contactsService.GetContactsAsync(50);

            Contacts = new ObservableGroupedCollection<string, Contact>(
                contacts.Contacts
                .GroupBy(static c => char.ToUpperInvariant(c.Name.First[0]).ToString())
                .OrderBy(static g => g.Key));

            OnPropertyChanged(nameof(Contacts));
        }

        [RelayCommand(FlowExceptionsToTaskScheduler = true)]
        private async Task LoadMoreContactsAsync()
        {
            ContactsQueryResponse contacts = await _contactsService.GetContactsAsync(10);

            foreach(Contact contact in contacts.Contacts)
            {
                string key = char.ToUpperInvariant(contact.Name.First[0]).ToString();

                Contacts.InsertItem(
                    key: key,
                    keyComparer: Comparer<string>.Default,
                    item: contact,
                    itemComparer: Comparer<Contact>.Create(static (left, right) => Comparer<string>.Default.Compare(left.ToString(), right.ToString())));
            }
        }

        [RelayCommand]
        private void DeleteContact(Contact contact)
        {
            Contacts.FirstGroupByKey(char.ToUpperInvariant(contact.Name.First[0]).ToString()).Remove(contact);
        }
    }
}
