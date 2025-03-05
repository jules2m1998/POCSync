using POCSync.Domain.Abstractions;

namespace POCSync.Domain.Models;

public class StorageLocation : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<PackageStorageHistory> PackageStorageHistories { get; set; } = [];
}
