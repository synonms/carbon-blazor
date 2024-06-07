using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Infrastructure;
using Synonms.CarbonBlazor.Models;
using Synonms.Functional;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class ReadResourcePage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    protected readonly string CollectionPath;
    protected TResource? Resource;
    protected readonly List<BreadcrumbItem> Breadcrumbs;

    protected ReadResourcePage(string collectionName, string resourceName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{CollectionPageUri}"),
            new BreadcrumbItem(resourceName, $"/{CollectionPageUri}/{Id}")
        ];
    }
    
    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Parameter]
    [EditorRequired]
    public Guid Id { get; set; }

    protected virtual Action<HttpRequestMessage>? RequestConfiguration { get; set; }

    protected virtual string CollectionPageUri => CollectionPath;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await RefreshResourceAsync();
    }
    
    protected async Task RefreshResourceAsync()
    {
        string uri = CollectionPath + "/" + Id;
        
        // TODO: Get uri from service root
        Result<ResourceDocument<TResource>> response = await HttpClient.GetByIdAsync<TResource>(uri, RequestConfiguration);

        response.Match(
            resourceDocument =>
            {
                Resource = resourceDocument.Resource;
            },
            fault =>
            {
                NotificationBroker.Send("Server error", $"Fault occurred retrieving resource from URI '{uri}': {fault}", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Error);

                Resource = new TResource();
            });
    }
}