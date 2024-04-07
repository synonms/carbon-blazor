using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Models;
using Synonms.Functional;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class EditResourcePage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    protected readonly string CollectionPath;
    protected TResource? Resource;
    protected readonly List<BreadcrumbItem> Breadcrumbs;

    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public Guid Id { get; set; }

    protected EditResourcePage(string collectionName, string resourceName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs = 
        [
            new BreadcrumbItem(collectionName, $"/{collectionPath}"),
            new BreadcrumbItem(resourceName, $"/{collectionPath}/{Id}"),
            new BreadcrumbItem("Edit", $"/{collectionPath}/{Id}/edit")
        ];
    }
    
    protected override async Task OnInitializedAsync()
    {
        await RefreshResourceAsync();
    }

    protected virtual async Task RefreshResourceAsync()
    {
        (await HttpClient.GetByIdAsync<TResource>($"{CollectionPath}/{Id}", CancellationToken.None))
            .Match(
                resourceDocument =>
                {
                    Resource = resourceDocument.Resource;
                }, 
                fault =>
                {
                    // TODO
                    Console.WriteLine($"FAULT - {GetType().Name}.{nameof(RefreshResourceAsync)}: " + fault);
                });
    }

    protected virtual async Task OnFormSubmittedAsync(TResource resource)
    {
        Console.WriteLine("Sending resource:\r\n" + JsonSerializer.Serialize(resource));
        
        // TODO: Get Uri from link
        Maybe<Fault> outcome = await HttpClient.PutAsync($"{CollectionPath}/{Id}", resource, CancellationToken.None);

        outcome.Match(
            fault =>
            {
                Console.WriteLine("Received Fault:\r\n" + fault);
                // TODO: Inform user
            },
            () =>
            {
                Console.WriteLine("Received Success!");
                // TODO: Inform user
                
                NavigationManager.NavigateTo($"{CollectionPath}/{Id}");
            });
    }
}