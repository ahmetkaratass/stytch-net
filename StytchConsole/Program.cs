using Microsoft.Extensions.DependencyInjection;
using Stytch.Extensions;
using Stytch.MagicLink;

class Program
{
    static void Main(string[] args)
    {
        var projectId = "";
        var projectSecret = "";
        var env = "test";

        var services = new ServiceCollection();
        services.AddStytch(projectId, projectSecret, env);
        var serviceProvider = services.BuildServiceProvider();
        var magicLinkService = serviceProvider.GetRequiredService<IMagicLinkService>();
    }
}
