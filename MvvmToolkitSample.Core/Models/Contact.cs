using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MvvmToolkitSample.Core.Models
{
    public sealed record ContactsQueryResponse([property: JsonPropertyName("results")] IList<Contact> Contacts);

    public sealed record Contact(
        [property: JsonPropertyName("name")] Name Name,
        [property: JsonPropertyName("email")] string Email,
        [property: JsonPropertyName("picture")] Picture Picture);

    public sealed record Name(
        [property: JsonPropertyName("first")] string First,
        [property: JsonPropertyName("last")] string Last)
    {
        public override string ToString()
        {
            return $"{First} {Last}";
        }
    }

    public sealed record Picture([property: JsonPropertyName("thumbnail")] string Url);
}
