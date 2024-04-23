using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Models;
using Synonms.CarbonBlazor.Serialisation;
using Synonms.Functional;
using Synonms.RestEasy.Core.Schema;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Pages;

public abstract class ResourcesPage<TResource> : ComponentBase
    where TResource : Resource, new()
{
    public enum Mode
    {
        None = 0,
        Create,
        Read,
        Update,
        Delete
    }
    
    protected readonly string CollectionPath;
    protected List<TResource>? Resources;
    protected Pagination? Pagination;
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    private Mode _mode = Mode.None;
    private string _activeResourceJson = string.Empty;
    
    [Inject] 
    public ICarbonBlazorHttpClient HttpClient { get; set; } = null!;

    public TResource ActiveResource { get; set; } = new();
    
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
    
    protected async Task RefreshResourcesAsync(int offset)
    {
        // TODO: Get uri from service root
        Result<ResourceCollectionDocument<TResource>> response = await HttpClient.GetAllAsync<TResource>(CollectionPath + "?limit=0&offset=" + offset, CancellationToken.None);

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

    protected void BeginOperation(Mode mode, TResource resource)
    {
        _mode = mode;
        ActiveResource = resource;
        _activeResourceJson = JsonSerializer.Serialize(resource, DefaultSerialiser.JsonSerializerOptions);
        
        switch (mode)
        {
            case Mode.None:
                break;
            case Mode.Create:
                OnBeginCreate();
                break;
            case Mode.Read:
                OnBeginRead();
                break;
            case Mode.Update:
                OnBeginUpdate();
                break;
            case Mode.Delete:
                OnBeginDelete();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }

    protected void CancelOperation()
    {
        if (_mode == Mode.Update)
        {
            // Revert resource back to its original state
            ActiveResource = JsonSerializer.Deserialize<TResource>(_activeResourceJson, DefaultSerialiser.JsonSerializerOptions) ?? new TResource();
            if (ActiveResource.Id != Guid.Empty && Resources is not null)
            {
                int index = Resources.FindIndex(x => x.Id == ActiveResource.Id);
                if (index >= 0)
                {
                    Resources[index] = ActiveResource;
                }
            }
        }

        OnCancel(_mode, ActiveResource);
        
        EndOperation();
    }

    protected async Task ConfirmOperation()
    {
        if (ActiveResource.Id == Guid.Empty)
        {
            EndOperation();
            return;
        }
        
        Maybe<Fault> outcome = _mode switch
        {
            Mode.Create => await HttpClient.PostAsync(CollectionPath, ActiveResource, CancellationToken.None),
            Mode.Update => await HttpClient.PutAsync(CollectionPath + "/" + ActiveResource.Id, ActiveResource, CancellationToken.None),
            Mode.Delete => await HttpClient.DeleteAsync(CollectionPath + "/" + ActiveResource.Id, CancellationToken.None),
            _ => Maybe<Fault>.None
        };

        await outcome.MatchAsync(
            async fault => await OnFault(_mode, ActiveResource, fault),
            async () => await OnSuccess(_mode, ActiveResource));

        EndOperation();
    }

    protected void EndOperation()
    {
        _mode = Mode.None;
        ActiveResource = new TResource();
    }

    protected abstract void OnBeginCreate();
    protected abstract void OnBeginRead();
    protected abstract void OnBeginUpdate();
    protected abstract void OnBeginDelete();
    protected abstract Task OnCancel(Mode mode, TResource? resource);
    protected abstract Task OnSuccess(Mode mode, TResource resource);
    protected abstract Task OnFault(Mode mode, TResource resource, Fault fault);
}