using System.Net;

namespace StytchAuth.Models.MagicLink;

public record RevokeInviteResponse(HttpStatusCode StatusCode, bool IsSuccessStatusCode)
    : BaseMagicLinkErrorResponse(StatusCode, IsSuccessStatusCode);
