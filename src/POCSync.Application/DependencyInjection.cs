using Microsoft.Extensions.DependencyInjection;

namespace POCSync.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection @this)
    {
        return @this;
    }
}
