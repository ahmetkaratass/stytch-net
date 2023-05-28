using System.Text.Json.Serialization;

namespace StytchAuth.Models.Shared;

public record Name(
    [property: JsonPropertyName("first_name")] string? FirstName = null,
    [property: JsonPropertyName("middle_name")] string? MiddleName = null,
    [property: JsonPropertyName("last_name")] string? LastName = null
);
