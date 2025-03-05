namespace POCSync.Infrastructure.Persistence.Data.Configurations;

public class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.TrackingNumber).IsUnique();
        builder.HasMany(x => x.PackageStorageHistories).WithOne(x => x.Package)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
