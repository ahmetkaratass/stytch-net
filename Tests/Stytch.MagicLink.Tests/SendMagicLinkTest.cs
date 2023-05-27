using Stytch.MagicLink.Tests.Mocks;
using Stytch.Models.MagicLink;

namespace Stytch.MagicLink.Tests;

public class SendMagicLinkTest
{
    private string _projectId = "projectId";
    private string _secret = "secret";
    private string _env = "env";

    [Theory]
    [InlineData(null, null, null, false)]
    [InlineData("id", null, null, false)]
    [InlineData("id", "secret", null, false)]
    [InlineData("id", "secret", "env", true)]
    public void InitializeMagicLink(string projectId, string secret, string env, bool success)
    {
        // Act
        var act = () => new MagicLink(new HttpClient(), projectId, secret, env);
        var exception = Record.Exception(act);

        // Assert
        if (success)
        {
            Assert.Null(exception);
        }
        else
        {
            Assert.NotNull(exception);
            Assert.Throws<ArgumentNullException>(act);
        }
    }

    [Theory]
    [InlineData("email/send")]
    [InlineData("email/login_or_create")]
    [InlineData("email/invite")]
    [InlineData("email/revoke_invite")]
    [InlineData("authenticate")]
    public void GetUrl(string url)
    {
        // Arrange
        var magicLink = new MagicLink(new HttpClient(), _projectId, _secret, _env);

        // Act
        var res = magicLink.GetUrl(url);

        // Assert
        Assert.Equal(res, $"https://{_env}.stytch.com/v1/magic_links/{url}");
    }

    [Fact]
    public async Task SendMagicLink_200_Simple()
    {
        // Arrange
        var email = "test@example.com";
        var sendMagicLinkParams = new SendMagicLinkParams(email);
        var response = new SendMagicLinkResponse
        {
            StatusCode = 200,
            RequestId = "request-id-test-12031230841093",
            UserId = "user-test-12031230841093",
            EmailId = "email-test-12031230841093"
        };

        var mockHttpMessageHandler = new MockHttpMessageHandler<SendMagicLinkResponse>(response);

        var magicLink = new MagicLink(
            new HttpClient(mockHttpMessageHandler),
            _projectId,
            _secret,
            _env
        );

        // Act
        var result = await magicLink.SendMagicLink(sendMagicLinkParams);

        // Assert
        Assert.Null(result.ErrorMessage);
        Assert.Null(result.ErrorType);
        Assert.Null(result.ErrorUrl);

        Assert.Equal(result.StatusCode, 200);
        Assert.NotNull(result.RequestId);
        Assert.NotNull(result.UserId);
        Assert.NotNull(result.EmailId);
        Assert.IsType<SendMagicLinkResponse>(result);
    }


}
