using POCSync.Domain.Abstractions;

namespace POCSync.Domain.Models;

public class Package : Entity<Guid>
{
    public string TrackingNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<PackageStorageHistory> PackageStorageHistories { get; set; } = [];
}
