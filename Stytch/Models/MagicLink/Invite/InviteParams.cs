using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record InviteParams(
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("invite_magic_link_url")] string? InviteMagicLinkUrl = null,
    [property: JsonPropertyName("invite_expiration_minutes")] int? InviteExpirationMinutes = null,
    [property: JsonPropertyName("invite_template_id")] string? InviteTemplateId = null,
    [property: JsonPropertyName("name")] object? Name = null,
    [property: JsonPropertyName("locale")] string? Locale = null,
    [property: JsonPropertyName("attributes")] object? Attributes = null
);
