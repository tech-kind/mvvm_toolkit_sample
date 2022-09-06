using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MvvmToolkitSample.Core.Services;

namespace MvvmToolkitSample.Core.ViewModels
{
    public class MessengerPageViewModel : SamplePageViewModel
    {
        public MessengerPageViewModel(IFileService fileService)
            : base(fileService)
        {
            RequestCurrentUsernameCommand = new RelayCommand(RequestCurrentUsername);
            ResetCurrentUsernameCommand = new RelayCommand(ResetCurrentUsername);
        }

        public ICommand RequestCurrentUsernameCommand { get; }

        public ICommand ResetCurrentUsernameCommand { get; }

        public UserSenderViewModel SenderViewModel { get; } = new();

        public UserReceiverViewModel ReceiverViewModel { get; } = new();

        public class UserSenderViewModel : ObservableRecipient
        {
            public UserSenderViewModel()
            {
                SendUserMesageCommand = new RelayCommand(SendUserMessage);
            }

            public ICommand SendUserMesageCommand { get; }

            private string _username = "Bob";

            public string Username
            {
                get => _username;
                private set => SetProperty(ref _username, value);
            }

            protected override void OnActivated()
            {
                Messenger.Register<UserSenderViewModel, CurrentUsernameRequestMessage>(this, (r, m) => m.Reply(r.Username));
            }

            public void SendUserMessage()
            {
                Username = Username == "Bob" ? "Alice" : "Bob";

                Messenger.Send(new UsernameChangedMessage(Username));
            }
        }

        public class UserReceiverViewModel : ObservableRecipient
        {
            private string _username = "";

            public string Username
            {
                get => _username;
                private set => SetProperty(ref _username, value);
            }

            protected override void OnActivated()
            {
                Messenger.Register<UserReceiverViewModel, UsernameChangedMessage>(this, (r, m) => r.Username = m.Value);
            }
        }

        private string? _username;

        public string? Username
        {
            get => _username;
            private set => SetProperty(ref _username, value);
        }

        public void RequestCurrentUsername()
        {
            Username = WeakReferenceMessenger.Default.Send<CurrentUsernameRequestMessage>();
        }

        public void ResetCurrentUsername()
        {
            Username = null;
        }

        // A sample message with a username value
        public sealed class UsernameChangedMessage : ValueChangedMessage<string>
        {
            public UsernameChangedMessage(string value) : base(value)
            {
            }
        }

        // A sample request message to get the current username
        public sealed class CurrentUsernameRequestMessage : RequestMessage<string>
        {
        }
    }
}
