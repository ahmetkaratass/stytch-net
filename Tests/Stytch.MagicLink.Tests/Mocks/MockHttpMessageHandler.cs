using System.Text;
using System.Text.Json;

namespace Stytch.MagicLink.Tests.Mocks;

public class MockHttpMessageHandler<T> : HttpMessageHandler
{
    private readonly T _responseContent;

    public MockHttpMessageHandler(T responseContent)
    {
        _responseContent = responseContent;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var response = new HttpResponseMessage()
        {
            Content = new StringContent(
                JsonSerializer.Serialize(_responseContent),
                Encoding.UTF8,
                "application/json"
            )
        };
        return await Task.FromResult(response);
    }
}
