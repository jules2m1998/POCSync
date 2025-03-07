namespace POCSync.Domain.Services;

public interface IEventHandler<EventType>
    where EventType : class
{
    Task<EventType> HandleAsync(EventType @event);
}
