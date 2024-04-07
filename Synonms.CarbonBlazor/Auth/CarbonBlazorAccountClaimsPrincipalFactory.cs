using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Synonms.RestEasy.Core.Auth;

namespace Synonms.CarbonBlazor.Auth;

public class CarbonBlazorAccountClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor, IPermissionProvider permissionProvider) : AccountClaimsPrincipalFactory<RemoteUserAccount>(accessor)
{
    public IPermissionProvider PermissionProvider { get; private set; } = permissionProvider;
    
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
    {
        ClaimsPrincipal initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is null || initialUser.Identity.IsAuthenticated is false)
        {
            return initialUser;
        }

        Guid? userId = initialUser.GetUserId();

        if (userId is null)
        {
            return initialUser;
        }
        
        ClaimsIdentity? claimsIdentity = await PermissionProvider.GetAsync(userId.Value, CancellationToken.None);

        if (claimsIdentity is not null)
        {
            initialUser.AddIdentity(claimsIdentity);
        }

        return initialUser;
    }
}