using Microsoft.AspNetCore.Components;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class MultiTenantCreateResourcePage<TResource> : CreateResourcePage<TResource>
    where TResource : Resource, new()
{
    protected MultiTenantCreateResourcePage(string collectionName, string collectionPath) 
        : base(collectionName, collectionPath)
    {
    }
    
    [Parameter]
    public Guid TenantId { get; set; }
    
    protected override string CollectionPageUri => $"tenants/{TenantId}/{CollectionPath}";

    protected override Action<HttpRequestMessage>? RequestConfiguration => httpRequestMessage =>
        httpRequestMessage.Headers.Add("X-RestEasy-Tenant-ID", TenantId.ToString());
}