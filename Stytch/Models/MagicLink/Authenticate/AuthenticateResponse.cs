using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record AuthenticateResponse(
    [property: JsonPropertyName("method_id")] string? MethodId = null,
    [property: JsonPropertyName("reset_sessions")] bool? ResetSessions = null,
    [property: JsonPropertyName("session")] object? Session = null,
    [property: JsonPropertyName("session_jwt")] string? SessionJwt = null,
    [property: JsonPropertyName("session_token")] string? SessionToken = null,
    [property: JsonPropertyName("user")] object? User = null,
    [property: JsonPropertyName("user_id")] string? UserId = null
) : BaseMagicLinkErrorResponse;
