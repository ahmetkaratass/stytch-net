using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record BaseMagicLinkResponse(
    [property: JsonPropertyName("status_code")] int? StatusCode = null,
    [property: JsonPropertyName("request_id")] string? RequestId = null,
    [property: JsonPropertyName("user_id")] string? UserId = null,
    [property: JsonPropertyName("email_id")] string? EmailId = null
) : BaseMagicLinkErrorResponse;
