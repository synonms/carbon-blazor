﻿using Microsoft.AspNetCore.Components;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class MultiTenantReadResourcePage<TResource> : ReadResourcePage<TResource>
    where TResource : Resource, new()
{
    protected MultiTenantReadResourcePage(string collectionName, string resourceName, string collectionPath) 
        : base(collectionName, resourceName, collectionPath)
    {
    }
    
    [Parameter]
    public Guid TenantId { get; set; }
    
    protected override string CollectionPageUri => $"tenants/{TenantId}/{CollectionPath}";

    protected override Action<HttpRequestMessage>? RequestConfiguration => httpRequestMessage =>
        httpRequestMessage.Headers.Add("X-RestEasy-Tenant-ID", TenantId.ToString());
}