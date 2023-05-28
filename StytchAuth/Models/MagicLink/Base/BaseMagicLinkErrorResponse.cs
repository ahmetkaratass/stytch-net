using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record BaseMagicLinkErrorResponse(
    [property: JsonPropertyName("status_code")] int? StatusCode = null,
    [property: JsonPropertyName("request_id")] string? RequestId = null,
    [property: JsonPropertyName("error_type")] string? ErrorType = null,
    [property: JsonPropertyName("error_message")] string? ErrorMessage = null,
    [property: JsonPropertyName("error_url")] string? ErrorUrl = null
);
