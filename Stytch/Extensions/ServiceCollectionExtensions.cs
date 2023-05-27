using Microsoft.Extensions.DependencyInjection;
using Stytch.MagicLink;

namespace Stytch.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStytch(
        this IServiceCollection services,
        string projectId,
        string secret,
        string env
    )
    {
        services.AddHttpClient();
        services.AddScoped<IMagicLinkService, MagicLinkService>(
            (serviceProvider) =>
                new MagicLinkService(
                    serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient(),
                    projectId,
                    secret,
                    env
                )
        );
        
        return services;
    }
}
