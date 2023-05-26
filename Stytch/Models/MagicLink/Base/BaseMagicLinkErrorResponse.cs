using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record BaseMagicLinkErrorResponse(
    [property: JsonPropertyName("error_type")] string? ErrorType = null,
    [property: JsonPropertyName("error_message")] string? ErrorMessage = null,
    [property: JsonPropertyName("error_url")] string? ErrorUrl = null
);
