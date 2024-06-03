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
    private readonly string _collectionPath;
    private string _originalResourceJson = string.Empty;
    
    protected TResource Resource = new();
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    
    protected CreateResourcePage(string collectionName, string collectionPath)
    {
        _collectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{collectionPath}"),
            new BreadcrumbItem("Add", $"/{collectionPath}/add")
        ];
    }

    protected virtual void OnSuccess()
    {
        NotificationBroker.Send("Resource created", $"Resource Id '{Resource.Id}' created successfully.", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success);

        NavigationManager.NavigateTo(_collectionPath);
    }

    protected virtual void OnFault(Fault fault) =>
        NotificationBroker.Send("Server error", $"Fault occurred creating resource Id '{Resource.Id}': {fault}", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Error);

    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected async Task Submit() =>
        await HttpClient.PostAsync(_collectionPath, Resource)
            .MatchAsync(OnFault, OnSuccess);
    
    protected void ResetResource() =>
        Resource = new TResource();
}