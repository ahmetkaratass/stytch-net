using System.Net;
using System.Text;
using System.Text.Json;

namespace StytchAuth.MagicLink.Tests.Mocks;

public class MockHttpMessageHandler<T> : HttpMessageHandler
{
    private readonly T _responseContent;
    private readonly HttpStatusCode _httpStatusCode;

    public MockHttpMessageHandler(HttpStatusCode statusCode, T responseContent)
    {
        _httpStatusCode = statusCode;
        _responseContent = responseContent;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var response = new HttpResponseMessage()
        {
            StatusCode = _httpStatusCode,
            Content = new StringContent(
                JsonSerializer.Serialize(_responseContent),
                Encoding.UTF8,
                "application/json"
            )
        };
        return await Task.FromResult(response);
    }
}
