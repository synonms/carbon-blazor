using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Models;
using Synonms.Functional;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class AddResourcePage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    protected readonly string CollectionPath;
    protected readonly TResource Resource = new();
    protected readonly List<BreadcrumbItem> Breadcrumbs;

    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;

    protected AddResourcePage(string collectionName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs = 
        [
            new BreadcrumbItem(collectionName, $"/{collectionPath}"), 
            new BreadcrumbItem("Add", $"/{collectionPath}/add")
        ];
    }
    
    protected virtual async Task OnFormSubmittedAsync(TResource resource)
    {
        Console.WriteLine("Sending resource:\r\n" + JsonSerializer.Serialize(resource));
        
        Maybe<Fault> outcome = await HttpClient.PostAsync(CollectionPath, resource, CancellationToken.None);

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
                
                NavigationManager.NavigateTo(CollectionPath);
            });
    }
}