using Microsoft.Extensions.DependencyInjection;
using POCSync.Domain.Services;

namespace POCSync.Event;

public class EventEmitter<TEvent>(IServiceProvider service)
    : IEventEmitter<TEvent> where TEvent : Domain.Abstractions.Event
{
    public Task<TEvent> Send(TEvent @event)
    {
        using var scope = service.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<TEvent>>() ??
            throw new InvalidOperationException($"No handlers registered for event type {typeof(TEvent).Name}");

        var result = handler.HandleAsync(@event);
        return result;
    }
}
