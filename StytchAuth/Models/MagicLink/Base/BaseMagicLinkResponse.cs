using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record BaseMagicLinkResponse(
    [property: JsonPropertyName("user_id")] string? UserId = null,
    [property: JsonPropertyName("email_id")] string? EmailId = null
) : BaseMagicLinkErrorResponse;
