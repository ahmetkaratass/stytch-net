using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record AuthenticateResponse(
    [property: JsonPropertyName("method_id")] string? MethodId = null,
    [property: JsonPropertyName("reset_sessions")] bool? ResetSessions = null,
    // TODO: Create Session Class
    [property: JsonPropertyName("session")] object? Session = null,
    [property: JsonPropertyName("session_jwt")] string? SessionJwt = null,
    [property: JsonPropertyName("session_token")] string? SessionToken = null,
    // TODO: Create User Class
    [property: JsonPropertyName("user")] object? User = null,
    [property: JsonPropertyName("user_id")] string? UserId = null
) : BaseMagicLinkErrorResponse;
