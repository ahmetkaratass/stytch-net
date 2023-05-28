using Microsoft.Extensions.DependencyInjection;
using StytchAuth.MagicLink;

namespace StytchAuth.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStytchAuth(
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
