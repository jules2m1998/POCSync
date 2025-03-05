using POCSync.Domain.Abstractions;

namespace POCSync.Domain.Models;

public class PackageStorageHistory : Entity
{
    public virtual Package Package { get; set; } = default!;
    public virtual StorageLocation StorageLocation { get; set; } = default!;
}
