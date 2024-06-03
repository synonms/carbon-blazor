using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Infrastructure;
using Synonms.CarbonBlazor.Models;
using Synonms.CarbonBlazor.Serialisation;
using Synonms.Functional;
using Synonms.Functional.Extensions;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class UpdateResourcePage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    private readonly string _collectionPath;
    private string _originalResourceJson = string.Empty;
    
    protected TResource? Resource;
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    
    protected UpdateResourcePage(string collectionName, string resourceName, string collectionPath)
    {
        _collectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{collectionPath}"),
            new BreadcrumbItem(resourceName, $"/{collectionPath}/{Id}"),
            new BreadcrumbItem("Edit", $"/{collectionPath}/{Id}/edit")
        ];
    }

    protected virtual void OnSuccess()
    {
        NotificationBroker.Send("Resource updated", $"Resource Id '{Id}' updated successfully.", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success);

        NavigationManager.NavigateTo(_collectionPath);
    }

    protected virtual void OnFault(Fault fault) =>
        NotificationBroker.Send("Server error", $"Fault occurred updating resource Id '{Id}': {fault}", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Error);

    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    [EditorRequired]
    public Guid Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await RefreshResourceAsync();
    }
    
    protected async Task RefreshResourceAsync()
    {
        string uri = _collectionPath + "/" + Id;
        
        // TODO: Get uri from service root
        Result<ResourceDocument<TResource>> response = await HttpClient.GetByIdAsync<TResource>(uri);

        response.Match(
            resourceDocument =>
            {
                Resource = resourceDocument.Resource;
                _originalResourceJson = JsonSerializer.Serialize(Resource, DefaultSerialiser.JsonSerializerOptions);
            },
            fault =>
            {
                NotificationBroker.Send("Server Error", $"Fault occurred retrieving resource from URI '{uri}': {fault}");

                Resource = new TResource();
            });
    }

    protected async Task Submit()
    {
        if (Resource is null)
        {
            return;
        }
        
        await HttpClient.PutAsync(_collectionPath + "/" + Id, Resource)
            .MatchAsync(OnFault, OnSuccess);
    }
    
    protected void ResetResource() =>
        Resource = JsonSerializer.Deserialize<TResource>(_originalResourceJson, DefaultSerialiser.JsonSerializerOptions) ?? new TResource();
}