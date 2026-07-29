using Logistics.Core.Abstractions;
using Logistics.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Logistics.Core;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the shared logistics services. Called from both hosts so the web app
    /// and the MAUI app resolve the same implementations with the same lifetimes.
    /// </summary>
    public static IServiceCollection AddLogisticsCore(this IServiceCollection services)
    {
        services.AddSingleton<IShipmentService, InMemoryShipmentService>();

        return services;
    }
}
