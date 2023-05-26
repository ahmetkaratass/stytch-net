using System.Text.Json.Serialization;

namespace Stytch.Models.MagicLink;

public record LoginOrCreateResponse(
    [property: JsonPropertyName("user_created")] bool? UserCreated = null
) : BaseMagicLinkResponse();
