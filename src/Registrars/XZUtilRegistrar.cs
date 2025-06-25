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
    public static IServiceCollection AddXZUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IXZUtil, XZUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IXZUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddXZUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IXZUtil, XZUtil>();

        return services;
    }
}
