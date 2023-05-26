using System.Text;

namespace Stytch.Extensions;

public static class AuthenticationExtensions
{
    public static string CreateBasicAuthentication(string projectId, string secret) =>
        Convert.ToBase64String(Encoding.UTF8.GetBytes(projectId + ":" + secret));
}
