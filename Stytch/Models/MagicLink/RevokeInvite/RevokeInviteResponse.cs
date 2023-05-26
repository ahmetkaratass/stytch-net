using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record RevokeInviteResponse(
    [property: JsonPropertyName("status_code")] int? StatusCode = null,
    [property: JsonPropertyName("request_id")] string? RequestId = null
) : BaseMagicLinkErrorResponse;
