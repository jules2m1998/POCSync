namespace POCSync.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection @this, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        @this.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        @this.AddScoped<IDbContext, SyncDbContext>();
        @this.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

        @this.AddDbContext<SyncDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        return @this;
    }
}
