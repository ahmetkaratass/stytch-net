using Microsoft.Extensions.DependencyInjection;
using StytchAuth.Extensions;
using StytchAuth.MagicLink;

class Program
{
    static void Main(string[] args)
    {
        var projectId = "";
        var projectSecret = "";
        var env = "test";

        var services = new ServiceCollection();
        services.AddStytchAuth(projectId, projectSecret, env);
        var serviceProvider = services.BuildServiceProvider();
        var magicLinkService = serviceProvider.GetRequiredService<IMagicLinkService>();
    }
}
