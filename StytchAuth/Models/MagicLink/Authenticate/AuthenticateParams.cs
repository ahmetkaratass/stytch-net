using System.Text.Json.Serialization;
using StytchAuth.Models.Shared;

namespace StytchAuth.Models.MagicLink;

public record AuthenticateParams(
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("options")] Options? Options = null,
    [property: JsonPropertyName("attributes")] Attributes? Attributes = null,
    [property: JsonPropertyName("session_duration_minutes")] string? SessionDurationMinutes = null,
    [property: JsonPropertyName("session_custom_claims")]
        Dictionary<string, object>? SessionCustomClaims = null,
    [property: JsonPropertyName("session_jwt")] string? SessionJwt = null,
    [property: JsonPropertyName("session_token")] string? SessionToken = null,
    [property: JsonPropertyName("code_verifier")] string? CodeVerifier = null
);
