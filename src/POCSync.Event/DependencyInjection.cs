using Microsoft.Extensions.DependencyInjection;
using POCSync.Domain.Services;

namespace POCSync.Event;

public static class DependencyInjection
{
    public static IServiceCollection AddEventsHandling(this IServiceCollection @this)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var handlerTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var implementedInterfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));

            foreach (var serviceType in implementedInterfaces)
            {
                @this.AddScoped(serviceType, handlerType);
            }
        }

        @this.AddScoped(typeof(IEventEmitter<>), typeof(EventEmitter<>));

        return @this;
    }
}
