using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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
    protected ClaimsPrincipal? ClaimsPrincipal;
    protected readonly string CollectionPath;
    protected string OriginalResourceJson = string.Empty;
    protected TResource? Resource;
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    
    protected UpdateResourcePage(string collectionName, string resourceName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{CollectionPageUri}"),
            new BreadcrumbItem(resourceName, $"/{CollectionPageUri}/{Id}"),
            new BreadcrumbItem("Edit", $"/{CollectionPageUri}/{Id}/edit")
        ];
    }
    
    protected virtual void OnSuccess()
    {
        NotificationBroker.Send("Resource updated", $"Resource Id '{Id}' updated successfully.", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Success);

        NavigationManager.NavigateTo(CollectionPageUri);
    }

    protected virtual void OnFault(Fault fault) =>
        NotificationBroker.Send("Server error", $"Fault occurred updating resource Id '{Id}': {fault}", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Error);

    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    [EditorRequired]
    public Guid Id { get; set; }

    protected virtual Action<HttpRequestMessage>? RequestConfiguration { get; set; }

    protected virtual string CollectionPageUri => CollectionPath;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        AuthenticationState authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        ClaimsPrincipal = authenticationState.User;

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
                OriginalResourceJson = JsonSerializer.Serialize(Resource, DefaultSerialiser.JsonSerializerOptions);
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
        
        await HttpClient.PutAsync(CollectionPath + "/" + Id, Resource, RequestConfiguration)
            .MatchAsync(OnFault, OnSuccess);
    }
    
    protected void ResetResource() =>
        Resource = JsonSerializer.Deserialize<TResource>(OriginalResourceJson, DefaultSerialiser.JsonSerializerOptions) ?? new TResource();
}