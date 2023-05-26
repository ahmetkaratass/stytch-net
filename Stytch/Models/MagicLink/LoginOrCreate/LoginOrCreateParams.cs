using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record LoginOrCreateParams(
    string Email,
    [property: JsonPropertyName("create_user_as_pending"),] bool? CreateUserAsPending = null
) : BaseMagicLinkParams(Email);
