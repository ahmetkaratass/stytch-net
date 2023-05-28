using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record BaseMagicLinkParams(
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("login_magic_link_url")] string? LoginMagicLinkUrl = null,
    [property: JsonPropertyName("signup_magic_link_url")] string? SignupMagicLinkUrl = null,
    [property: JsonPropertyName("login_expiration_minutes")] int? LoginExpirationMinutes = null,
    [property: JsonPropertyName("signup_expiration_minutes")] int? SignupExpirationMinutes = null,
    [property: JsonPropertyName("login_template_id")] string? LoginTemplateId = null,
    [property: JsonPropertyName("signup_template_id")] string? SignupTemplateId = null,
    [property: JsonPropertyName("locale")] string? Locale = null,
    [property: JsonPropertyName("attributes")] Attributes? Attributes = null,
    [property: JsonPropertyName("code_challenge")] string? CodeChallenge = null
);
