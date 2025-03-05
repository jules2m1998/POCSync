namespace POCSync.Domain.Abstractions;

public interface IEvent<TEntity, TEntityId> : IEntity<Guid>
{
    TEntityId EntityId { get; }
    string Type { get; }
    string Data { get; }
}
