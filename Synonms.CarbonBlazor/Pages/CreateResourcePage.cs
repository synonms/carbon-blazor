using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Infrastructure;
using Synonms.CarbonBlazor.Models;
using Synonms.Functional;
using Synonms.Functional.Extensions;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class CreateResourcePage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    protected readonly string CollectionPath;
    protected string OriginalResourceJson = string.Empty;
    protected TResource Resource = new();
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    
    protected CreateResourcePage(string collectionName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{CollectionPageUri}"),
            new BreadcrumbItem("Add", $"/{CollectionPageUri}/add")
        ];
    }

    protected virtual string CollectionPageUri => CollectionPath;
    
    protected virtual void OnSuccess()
    {
        NotificationBroker.Send("Resource created", $"Resource Id '{Resource.Id}' created successfully.", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success);

        NavigationManager.NavigateTo(CollectionPageUri);
    }

    protected virtual void OnFault(Fault fault) =>
        NotificationBroker.Send("Server error", $"Fault occurred creating resource Id '{Resource.Id}': {fault}", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Error);

    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected virtual Action<HttpRequestMessage>? RequestConfiguration { get; set; }

    protected async Task Submit() =>
        await HttpClient.PostAsync(CollectionPath, Resource, RequestConfiguration)
            .MatchAsync(OnFault, OnSuccess);
    
    protected void ResetResource() =>
        Resource = new TResource();
}