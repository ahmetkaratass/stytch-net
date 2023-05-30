using System.Net;
using StytchAuth.MagicLink.Tests.Mocks;
using StytchAuth.Models.MagicLink;

namespace StytchAuth.MagicLink.Tests;

public class SendMagicLinkTest
{
    [Fact]
    public async Task SendMagicLink_Success()
    {
        // Arrange
        var email = "test@example.com";
        var sendMagicLinkParams = new SendMagicLinkParams(email);
        var statusCode = HttpStatusCode.OK;
        var response = new SendMagicLinkResponse(statusCode, true)
        {
            RequestId = "request-id-test-12031230841093",
            UserId = "user-test-12031230841093",
            EmailId = "email-test-12031230841093",
        };

        var mockHttpMessageHandler = new MockHttpMessageHandler<SendMagicLinkResponse>(
            statusCode,
            response
        );

        var magicLink = new MagicLinkService(
            new HttpClient(mockHttpMessageHandler),
            Params.ProjectId,
            Params.Secret,
            Params.Env
        );

        // Act
        var result = await magicLink.SendMagicLink(sendMagicLinkParams);

        // Assert
        Assert.Null(result.ErrorMessage);
        Assert.Null(result.ErrorType);
        Assert.Null(result.ErrorUrl);

        Assert.Equal(statusCode, result.StatusCode);
        Assert.True(result.IsSuccessStatusCode);
        Assert.NotNull(result.RequestId);
        Assert.NotNull(result.UserId);
        Assert.NotNull(result.EmailId);
        Assert.IsType<SendMagicLinkResponse>(result);
    }

    [Fact]
    public async Task SendMagicLink_Error()
    {
        // Arrange
        var email = "test@example.com";
        var sendMagicLinkParams = new SendMagicLinkParams(email);
        var statusCode = HttpStatusCode.BadRequest;
        var response = new SendMagicLinkResponse(statusCode, false)
        {
            RequestId = "request-id-test-12031230841093",
            ErrorType = "invalid_email",
            ErrorMessage = "Email format is invalid",
            ErrorUrl = "https://stytch.com/docs/api/errors/400",
        };

        var mockHttpMessageHandler = new MockHttpMessageHandler<SendMagicLinkResponse>(
            statusCode,
            response
        );

        var magicLink = new MagicLinkService(
            new HttpClient(mockHttpMessageHandler),
            Params.ProjectId,
            Params.Secret,
            Params.Env
        );

        // Act
        var result = await magicLink.SendMagicLink(sendMagicLinkParams);

        // Assert
        Assert.NotNull(result.ErrorMessage);
        Assert.NotNull(result.ErrorType);
        Assert.NotNull(result.ErrorUrl);
        Assert.NotNull(result.RequestId);

        Assert.Equal(statusCode, result.StatusCode);
        Assert.False(result.IsSuccessStatusCode);
        Assert.Null(result.UserId);
        Assert.Null(result.EmailId);
        Assert.IsType<SendMagicLinkResponse>(result);
    }
}
