using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Models;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class ViewResourcePage<TResource> : ComponentBase
    where TResource : Resource
{
    protected readonly string CollectionPath;
    protected TResource? Resource;
    protected readonly List<BreadcrumbItem> Breadcrumbs;

    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    [Parameter]
    public Guid Id { get; set; }

    public ViewResourcePage(string collectionName, string resourceName, string collectionPath)
    {
        CollectionPath = collectionPath;
        Breadcrumbs =
        [
            new BreadcrumbItem(collectionName, $"/{collectionPath}/"),
            new BreadcrumbItem(resourceName, $"/{collectionPath}/{Id}")
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
}