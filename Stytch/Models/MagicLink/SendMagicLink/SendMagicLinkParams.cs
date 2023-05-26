using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record SendMagicLinkParams(
    string Email,
    [property: JsonPropertyName("user_id")] string? UserId = null,
    [property: JsonPropertyName("session_token")] string? SessionToken = null,
    [property: JsonPropertyName("session_jwt")] string? SessionJwt = null
) : BaseMagicLinkParams(Email);
