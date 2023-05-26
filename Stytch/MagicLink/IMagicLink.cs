using Stytch.Models.MagicLink;

namespace Stytch.MagicLink;

public interface IMagicLink
{
    Task<LoginOrCreateResponse> LoginOrCreate(LoginOrCreateParams loginOrCreateParams);
    Task<SendMagicLinkResponse> SendMagicLink(SendMagicLinkParams sendMagicLinkParams);
    Task<InviteResponse> Invite(InviteParams inviteParams);
    Task<RevokeInviteResponse> RevokeInvite(string email);
    Task Authenticate();
}
