using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record LoginOrCreateResponse(
    [property: JsonPropertyName("user_created")] bool? UserCreated = null
) : BaseMagicLinkResponse();
