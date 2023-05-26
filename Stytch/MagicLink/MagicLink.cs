using System.Net.Http.Json;
using Stytch.Models.MagicLink;
using Stytch.Extensions;

namespace Stytch.MagicLink;

public class MagicLink : IMagicLink
{
    public string ProjectId { get; set; } = "project-test-18a43ec3-a866-4f9f-9e16-ea4810ecd352";
    public string Secret { get; set; } = "secret-test-GlVyZ7BMQpRdhkw3Bq7mm5ehtdM5iUmoodc=";
    public string Env { get; set; } = "test";
    private readonly HttpClient _httpClient;

    public MagicLink(HttpClient httpClient) =>
        _httpClient = httpClient.AddBasicAuthentication(ProjectId, Secret);

    /// <summary>
    /// Send a magic link to an existing Stytch user using their email address
    /// </summary>
    /// <param name="sendMagicLinkParams">SendMagicLinkParams</param>
    /// <see>https://stytch.com/docs/api/send-by-email</see>
    /// <returns></returns>
    public async Task<SendMagicLinkResponse> SendMagicLink(SendMagicLinkParams sendMagicLinkParams)
    {
        var url = $"https://{Env}.stytch.com/v1/magic_links/email/send";
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
        var url = $"https://{Env}.stytch.com/v1/magic_links/email/login_or_create";
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
        var url = $"https://{Env}.stytch.com/v1/magic_links/email/invite";
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
        var url = $"https://{Env}.stytch.com/v1/magic_links/email/revoke_invite";
        var request = await _httpClient.PostAsJsonAsync(url, new { email = email });
        return await request.Content.ReadFromJsonAsync<RevokeInviteResponse>()
            ?? new RevokeInviteResponse();
    }
}
