using System.Net;

namespace StytchAuth.Models.MagicLink;

public record SendMagicLinkResponse(HttpStatusCode StatusCode, bool IsSuccessStatusCode)
    : BaseMagicLinkResponse(StatusCode, IsSuccessStatusCode) { }
