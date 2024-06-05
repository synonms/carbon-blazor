using Microsoft.AspNetCore.Components;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class MultiTenantResourcesPage<TResource> : ResourcesPage<TResource>
    where TResource : Resource, new()
{
    public MultiTenantResourcesPage(string collectionName, string collectionPath)
        : base(collectionName, collectionPath)
    {
    }
    
    [Parameter]
    public Guid TenantId { get; set; }

    protected override Action<HttpRequestMessage>? RequestConfiguration => httpRequestMessage =>
        httpRequestMessage.Headers.Add("X-RestEasy-Tenant-ID", TenantId.ToString());
}