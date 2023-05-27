using System.Net.Http.Json;
using Stytch.Models.MagicLink;
using Stytch.Extensions;

namespace Stytch.MagicLink;

public class MagicLinkService : IMagicLinkService
{
    private readonly string _env;
    private readonly HttpClient _httpClient;

    public MagicLinkService(HttpClient httpClient, string projectId, string secret, string env)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId);
        ArgumentNullException.ThrowIfNullOrEmpty(secret);
        _env = env ?? throw new ArgumentNullException(nameof(env));
        _httpClient = httpClient.AddBasicAuthentication(projectId, secret);
    }

    /// <summary>
    /// Send a magic link to an existing Stytch user using their email address
    /// </summary>
    /// <param name="sendMagicLinkParams">SendMagicLinkParams</param>
    /// <see>https://stytch.com/docs/api/send-by-email</see>
    /// <returns></returns>
    public async Task<SendMagicLinkResponse> SendMagicLink(SendMagicLinkParams sendMagicLinkParams)
    {
        var url = GetUrl("email/send");
        var request = await _httpClient.PostAsJsonAsync(url, sendMagicLinkParams);
        return await request.Content.ReadFromJsonAsync<SendMagicLinkResponse>()
            ?? new SendMagicLinkResponse();
    }

    /// <summary>
    /// Log in or create user by email (MagicLink)
    /// </summary>
    /// <param name="LoginOrCreateParams">LoginOrCreateParams</param>
    /// <see>https://stytch.com/docs/api/log-in-or-create-user-by-email</see>
    /// <returns>Task<MagicLinkResponse></returns>
    public async Task<LoginOrCreateResponse> LoginOrCreate(LoginOrCreateParams loginOrCreateParams)
    {
        var url = GetUrl("email/login_or_create");
        var request = await _httpClient.PostAsJsonAsync(url, loginOrCreateParams);
        return await request.Content.ReadFromJsonAsync<LoginOrCreateResponse>()
            ?? new LoginOrCreateResponse();
    }

    /// <summary>
    /// Create a User and send an invite Magic Link to the provided email.
    /// The User will be created with a pending status until they click the Magic Link in the invite email.
    /// </summary>
    /// <param name="inviteParams">InviteParams</param>
    /// <see>https://stytch.com/docs/api/invite-by-email</see>
    /// <returns>Task<InviteResponse></returns>
    public async Task<InviteResponse> Invite(InviteParams inviteParams)
    {
        var url = GetUrl("email/invite");
        var request = await _httpClient.PostAsJsonAsync(url, inviteParams);
        return await request.Content.ReadFromJsonAsync<InviteResponse>() ?? new InviteResponse();
    }

    /// <summary>
    /// Revoke a pending invite based on the email provided.
    /// </summary>
    /// <param name="email">string email</param>
    /// <see>https://stytch.com/docs/api/invite-by-email</see>
    /// <returns>Task<RevokeInviteResponse></returns>
    public async Task<RevokeInviteResponse> RevokeInvite(string email)
    {
        var url = GetUrl("email/revoke_invite");
        var request = await _httpClient.PostAsJsonAsync(url, new { email = email });
        return await request.Content.ReadFromJsonAsync<RevokeInviteResponse>()
            ?? new RevokeInviteResponse();
    }

    /// <summary>
    /// Authenticate a User given a Magic Link.
    /// This endpoint verifies that the Magic Link token is valid,
    /// hasn't expired or been previously used,
    /// and any optional security settings such as IP match or user agent match are satisfied.
    /// </summary>
    /// <param name="authenticateParams">AuthenticateParams</param>
    /// <see>https://stytch.com/docs/api/authenticate-magic-link</see>
    /// <returns>Task<AuthenticateResponse></returns>
    public async Task<AuthenticateResponse> Authenticate(AuthenticateParams authenticateParams)
    {
        var url = GetUrl("authenticate");
        var request = await _httpClient.PostAsJsonAsync(url, authenticateParams);
        return await request.Content.ReadFromJsonAsync<AuthenticateResponse>()
            ?? new AuthenticateResponse();
    }

    public string GetUrl(string url) => $"https://{_env}.stytch.com/v1/magic_links/{url}";
}
