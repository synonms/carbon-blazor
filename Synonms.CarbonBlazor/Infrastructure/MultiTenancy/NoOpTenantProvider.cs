using Synonms.CarbonBlazor.Models;

namespace Synonms.CarbonBlazor.Infrastructure.MultiTenancy;

public class NoOpTenantProvider : ITenantProvider
{
    public Task<IEnumerable<SelectItem<Guid>>> GetAvailableAsync(CancellationToken cancellationToken) =>
        Task.FromResult<IEnumerable<SelectItem<Guid>>>([SelectItem<Guid>.Create("No tenant selected", Guid.Empty)]);
}