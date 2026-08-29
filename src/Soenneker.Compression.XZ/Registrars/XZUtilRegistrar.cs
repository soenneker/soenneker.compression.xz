using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Compression.XZ.Abstract;

namespace Soenneker.Compression.XZ.Registrars;

/// <summary>
/// A utility library dealing with XZ compression and decompression
/// </summary>
public static class XZUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IXZUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddXZUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IXZUtil, XZUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IXZUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddXZUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IXZUtil, XZUtil>();

        return services;
    }
}
