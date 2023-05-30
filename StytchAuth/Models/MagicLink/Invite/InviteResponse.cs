using System.Net;

namespace StytchAuth.Models.MagicLink;

public record InviteResponse(HttpStatusCode StatusCode, bool IsSuccessStatusCode)
    : BaseMagicLinkResponse(StatusCode, IsSuccessStatusCode);
