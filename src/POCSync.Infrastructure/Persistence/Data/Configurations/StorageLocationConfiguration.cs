
namespace POCSync.Infrastructure.Persistence.Data.Configurations;

public class StorageLocationConfiguration : IEntityTypeConfiguration<StorageLocation>
{
    public void Configure(EntityTypeBuilder<StorageLocation> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.PackageStorageHistories)
            .WithOne(x => x.StorageLocation)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
