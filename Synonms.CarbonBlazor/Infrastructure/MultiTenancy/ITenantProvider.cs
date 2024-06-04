using Synonms.CarbonBlazor.Models;

namespace Synonms.CarbonBlazor.Infrastructure.MultiTenancy;

public interface ITenantProvider
{
    Task<IEnumerable<SelectItem<Guid>>> GetAvailableAsync(CancellationToken cancellationToken);
}