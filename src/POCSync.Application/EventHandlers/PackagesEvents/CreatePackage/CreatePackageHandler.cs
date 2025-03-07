using POCSync.Domain.Services;

namespace POCSync.Application.EventHandlers.PackagesEvents.CreatePackage;

public class CreatePackageHandler : IEventHandler<CreatePackageEvent>
{
    public async Task<CreatePackageEvent> HandleAsync(CreatePackageEvent @event)
    {
        await Task.CompletedTask;
        return @event;
    }
}
