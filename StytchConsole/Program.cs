using Microsoft.Extensions.DependencyInjection;
using Stytch.Extensions;
using Stytch.MagicLink;

class Program
{
    static void Main(string[] args)
    {
        var projectId = "project-test-18a43ec3-a866-4f9f-9e16-ea4810ecd352";
        var projectSecret = "secret-test-GlVyZ7BMQpRdhkw3Bq7mm5ehtdM5iUmoodc=";
        var env = "test";

        var services = new ServiceCollection();
        services.AddStytch(projectId, projectSecret, env);
        var serviceProvider = services.BuildServiceProvider();
        var magicLinkService = serviceProvider.GetRequiredService<IMagicLinkService>();
    }
}
