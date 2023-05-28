using StytchAuth.Models.MagicLink;

namespace StytchAuth.MagicLink;

public interface IMagicLinkService
{
    Task<LoginOrCreateResponse> LoginOrCreate(LoginOrCreateParams loginOrCreateParams);
    Task<SendMagicLinkResponse> SendMagicLink(SendMagicLinkParams sendMagicLinkParams);
    Task<InviteResponse> Invite(InviteParams inviteParams);
    Task<RevokeInviteResponse> RevokeInvite(string email);
    Task<AuthenticateResponse> Authenticate(AuthenticateParams authenticateParams);
}
