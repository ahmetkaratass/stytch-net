namespace StytchAuth.MagicLink.Tests;

public class MagicLinkTest
{
    [Theory]
    [InlineData(null, null, null, false)]
    [InlineData("id", null, null, false)]
    [InlineData("id", "secret", null, false)]
    [InlineData("id", "secret", "env", true)]
    public void InitializeMagicLink(string projectId, string secret, string env, bool success)
    {
        // Act
        var act = () => new MagicLinkService(new HttpClient(), projectId, secret, env);
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
        var magicLink = new MagicLinkService(
            new HttpClient(),
            Params.ProjectId,
            Params.Secret,
            Params.Env
        );

        // Act
        var res = magicLink.GetUrl(url);

        // Assert
        Assert.Equal(res, $"https://{Params.Env}.stytch.com/v1/magic_links/{url}");
    }
}
