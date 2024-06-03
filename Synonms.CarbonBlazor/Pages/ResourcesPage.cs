using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Client;
using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Infrastructure;
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

    protected List<TResource>? Resources;
    protected Pagination? Pagination;
    protected readonly List<BreadcrumbItem> Breadcrumbs;
    private readonly string CollectionPath;
    protected const string CreateSuccessMessageTemplate = "{0} Id '{1}' was created successfully.";
    protected const string UpdateSuccessMessageTemplate = "{0} Id '{1}' was updated successfully.";
    protected const string DeleteSuccessMessageTemplate = "{0} Id '{1}' was deleted successfully.";
    protected const string CreateFaultMessageTemplate = "Fault occurred while creating {0} Id '{1}' : {2}";
    protected const string UpdateFaultMessageTemplate = "Fault occurred while updating {0} Id '{1}' : {2}";
    protected const string DeleteFaultMessageTemplate = "Fault occurred while deleting {0} Id '{1}' : {2}";
    
    private Mode _mode = Mode.None;
    private string _activeResourceJson = string.Empty;
    
    [Inject]
    public INotificationBroker NotificationBroker { get; set; } = null!;

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
        string uri = CollectionPath + "?limit=0&offset=" + offset;
        
        // TODO: Get uri from service root
        Result<ResourceCollectionDocument<TResource>> response = await HttpClient.GetAllAsync<TResource>(uri);

        response.Match(
            resourceCollectionDocument =>
            {
                Resources = resourceCollectionDocument.Resources.ToList();
                Pagination = resourceCollectionDocument.Pagination;
            },
            fault =>
            {
                NotificationBroker.Send("Server error", $"Fault occurred retrieving resources from URI '{uri}': {fault}", CarbonBlazorNotificationStyle.LowContrast, CarbonBlazorNotificationLevel.Error);

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
        if (ActiveResource.Id == Guid.Empty && _mode is Mode.Update or Mode.Delete)
        {
            EndOperation();
            return;
        }
        
        Maybe<Fault> outcome = _mode switch
        {
            Mode.Create => await HttpClient.PostAsync(CollectionPath, ActiveResource),
            Mode.Update => await HttpClient.PutAsync(CollectionPath + "/" + ActiveResource.Id, ActiveResource),
            Mode.Delete => await HttpClient.DeleteAsync(CollectionPath + "/" + ActiveResource.Id),
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

    protected virtual Task OnBeginCreate() => Task.CompletedTask;

    protected virtual Task OnBeginRead() => Task.CompletedTask;

    protected virtual Task OnBeginUpdate() => Task.CompletedTask;

    protected virtual Task OnBeginDelete() => Task.CompletedTask;
    
    protected abstract Task OnCancel(Mode mode, TResource? resource);
    
    protected abstract Task OnSuccess(Mode mode, TResource resource);
    
    protected abstract Task OnFault(Mode mode, TResource resource, Fault fault);
}