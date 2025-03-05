

using Microsoft.EntityFrameworkCore.ChangeTracking;
using POCSync.Domain.Abstractions;

namespace POCSync.Infrastructure.Persistence.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    private void UpdateEntities(
        DbContext? context
        )
    {
        if (context == null) return;

        foreach (var item in context.ChangeTracker.Entries<IEntity>())
        {
            if (item.State == EntityState.Added)
            {
                item.Entity.CreatedAt = DateTime.UtcNow;
                item.Entity.CreatedBy = "";
            }

            if (item.State == EntityState.Added || item.State == EntityState.Modified || item.HasChangedOwnedEntities())
            {
                item.Entity.LastModified = DateTime.UtcNow;
                item.Entity.LastModifiedBy = "";
            }

        }
    }
}

public static class InterceptorExtensions
{
    public static bool HasChangedOwnedEntities(
        this EntityEntry entry
        ) =>
        entry.References.Any(r =>
            r.TargetEntry != null
            && r.TargetEntry.Metadata.IsOwned()
            && (
                r.TargetEntry.State == EntityState.Added
                || r.TargetEntry.State == EntityState.Modified
            )
        );
}

