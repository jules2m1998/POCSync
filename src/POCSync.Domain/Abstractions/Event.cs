using System.Text.Json;

namespace POCSync.Domain.Abstractions;

public enum EventStatus
{
    Dirty,
    Pending,
    Errored,
    Synced,
    Conflicted
}

public abstract class Event
{
    public Guid Id { get; set; }
    public string EventType { get; set; } = string.Empty;
    public string SerializedData { get; set; } = string.Empty;
    public EventStatus Status { get; set; } = EventStatus.Dirty;
    public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.Now;

    public virtual T? GetEntity<T>() where T : class =>
        JsonSerializer.Deserialize<T>(SerializedData);
}
