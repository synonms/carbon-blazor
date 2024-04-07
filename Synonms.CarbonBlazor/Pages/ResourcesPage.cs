using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Models;
using Synonms.Functional;
using Synonms.Functional.Extensions;
using Synonms.RestEasy.Core.Schema;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class ResourcesPage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    protected readonly string CollectionPath;
    protected List<TResource>? Resources;
    protected Pagination? Pagination;
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    protected int CurrentOffset = 0;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;
    
    protected ResourcesPage(string collectionName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{collectionPath}")
        ];
    }
    
    protected override async Task OnInitializedAsync()
    {
        await RefreshResourcesAsync(0);
    }
    
    protected virtual async Task OnPageChanged(int offset)
    {
        await RefreshResourcesAsync(offset);
    }

    protected virtual async Task RefreshResourcesAsync(int offset)
    {
        CurrentOffset = offset < 0 ? 0 : offset;
        
        // TODO: Get uri from service root
        Result<ResourceCollectionDocument<TResource>> response = await HttpClient.GetAllAsync<TResource>(CollectionPath + "?offset=" + CurrentOffset, CancellationToken.None);

        response.Match(
            resourceCollectionDocument =>
            {
                Resources = resourceCollectionDocument.Resources.ToList();
                Pagination = resourceCollectionDocument.Pagination;
            },
            fault =>
            {
                // TODO: Display errors for client

                Resources = new List<TResource>();
            });
    }

    protected virtual async Task OnResourceCreated(TResource resource) =>
        await HttpClient.PostAsync(CollectionPath, resource, CancellationToken.None)
            .MatchAsync(
                fault =>
                {
                    // TODO: Display errors for client
                    return Task.CompletedTask;
                },
                async () => await RefreshResourcesAsync(CurrentOffset));

    protected virtual async Task OnResourceDeleted(TResource resource) =>
        await HttpClient.DeleteAsync(CollectionPath + "/" + resource.Id, CancellationToken.None)
            .MatchAsync(
                fault =>
                {
                    // TODO: Display errors for client
                    return Task.CompletedTask;
                },
                async () => await RefreshResourcesAsync(CurrentOffset));

    protected virtual async Task OnResourceUpdated(TResource resource) =>
        await HttpClient.PutAsync(CollectionPath + "/" + resource.Id, resource, CancellationToken.None)
            .MatchAsync(
                fault =>
                {
                    // TODO: Display errors for client
                    return Task.CompletedTask;
                },
                async () => await RefreshResourcesAsync(CurrentOffset));

}