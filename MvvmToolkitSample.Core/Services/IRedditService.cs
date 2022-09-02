using System.Threading.Tasks;
using MvvmToolkitSample.Core.Models;
using Refit;

namespace MvvmToolkitSample.Core.Services
{
    public interface IRedditService
    {
        [Get("r/{subreddit}/.json")]
        Task<PostsQueryResponse> GetSubredditPostsAsync(string subreddit);
    }
}
