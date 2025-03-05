﻿namespace POCSync.Domain.Abstractions;

public abstract class Entity<T> : Entity, IEntity<T>
{
    public T Id { get; set; } = default!;
}

public abstract class Entity : IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public bool? IsActivated { get; set; } = false;
}
