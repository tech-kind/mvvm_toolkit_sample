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
        public string SelfText { get; } = string.Empty;
    }
}
