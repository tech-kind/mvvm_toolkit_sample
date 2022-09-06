using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MvvmToolkitSample.Core.Models;

namespace MvvmToolkitSample.Core.ViewModels.Widgets
{
    public sealed class PostWidgetViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<Post>>
    {
        private Post? _post;

        public Post? Post
        {
            get => _post;
            private set => SetProperty(ref _post, value);
        }

        public void Receive(PropertyChangedMessage<Post> message)
        {
            if (message.Sender.GetType() == typeof(SubredditWidgetViewModel) &&
                message.PropertyName == nameof(SubredditWidgetViewModel.SelectedPost))
            {
                Post = message.NewValue;
            }
        }
    }
}
