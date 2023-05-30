using System.Net;
using System.Text.Json.Serialization;

namespace StytchAuth.Models.MagicLink;

public record LoginOrCreateResponse(
    HttpStatusCode StatusCode,
    bool IsSuccessStatusCode,
    [property: JsonPropertyName("user_created")] bool? UserCreated = null
) : BaseMagicLinkResponse(StatusCode, IsSuccessStatusCode)
{
    public LoginOrCreateResponse()
        : this(0, false, null) { }
}
