namespace POCSync.Infrastructure.Persistence.Data;

public class SyncDbContext(DbContextOptions<SyncDbContext> options)
    : DbContext(options), IDbContext
{
    public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();
    public DbSet<Package> Packages => Set<Package>();
    public DbSet<PackageStorageHistory> PackageStorageHistories => Set<PackageStorageHistory>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
