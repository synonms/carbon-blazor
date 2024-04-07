using System.Security.Claims;

namespace Synonms.CarbonBlazor.Auth;

public interface IPermissionProvider
{
    Task<ClaimsIdentity?> GetAsync(Guid userId, CancellationToken cancellationToken);
}