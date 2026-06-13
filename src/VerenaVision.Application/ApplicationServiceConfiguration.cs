using System.Reflection;
using VerenaVision.Application.Registrars;
using Microsoft.Extensions.DependencyInjection;

namespace VerenaVision.Application;

public static class ApplicationServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
  
        services.AddApplicationHandlersFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddApplicationHandlersFromAssembly(
       this IServiceCollection services,
       Assembly assembly)
    {
        Guard.NotNull(assembly);

        var serviceRegistrar = new ApplicationHandlerRegistrar(services);
        serviceRegistrar.RegisterFromAssembly(assembly);
        return services;
    }

    internal static IServiceCollection AddApplicationHandlersFromTypes(
       this IServiceCollection services,
       Type[] handlerTypes)
    {
        var serviceRegistrar = new ApplicationHandlerRegistrar(services);
        serviceRegistrar.RegisterHandlerFromTypes(handlerTypes);
        return services;
    }
}
