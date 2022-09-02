using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MvvmToolkitSample.Core.Models
{
    public sealed record PostsQueryResponse([property: JsonPropertyName("data")] PostListing Data);

    public sealed record PostListing([property: JsonPropertyName("children")] IList<PostData> Items);

    public sealed record PostData([property: JsonPropertyName("data")] Post Data);

    public sealed record Post(
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("thumbnail")] string? Thumbnail)
    {
        [JsonIgnore]
        public string SelfText { get; } = string.Join(" ", Enumerable.Repeat(
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", 20));
    }
}
