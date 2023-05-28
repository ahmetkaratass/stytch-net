using System.Net.Http.Headers;

namespace StytchAuth.Extensions;

public static class HttpClientExtensions
{
    public static HttpClient AddBasicAuthentication(
        this HttpClient httpClient,
        string projectId,
        string secret
    )
    {
        var basicAuth = AuthenticationExtensions.CreateBasicAuthentication(projectId, secret);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic",
            basicAuth
        );

        return httpClient;
    }
}
