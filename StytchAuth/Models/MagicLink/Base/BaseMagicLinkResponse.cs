using System.Net;
using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record BaseMagicLinkResponse(
    HttpStatusCode StatusCode,
    bool IsSuccessStatusCode,
    [property: JsonPropertyName("user_id")] string? UserId = null,
    [property: JsonPropertyName("email_id")] string? EmailId = null
) : BaseMagicLinkErrorResponse(StatusCode, IsSuccessStatusCode);
