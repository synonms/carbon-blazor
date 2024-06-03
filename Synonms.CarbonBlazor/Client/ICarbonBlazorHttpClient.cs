using Synonms.Functional;
using Synonms.RestEasy.Core.Schema.Forms;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Client;

public interface ICarbonBlazorHttpClient
{
    Task<Result<FormDocument>> CreateFormAsync(string uri, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new());

    Task<Maybe<Fault>> DeleteAsync(string uri, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new());

    Task<Result<FormDocument>> EditFormAsync(string uri, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new());
    
    Task<Result<ResourceCollectionDocument<TResource>>> GetAllAsync<TResource>(string uri, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new()) where TResource : Resource;
    
    Task<Result<ResourceDocument<TResource>>> GetByIdAsync<TResource>(string uri, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new()) where TResource : Resource;

    Task<Result<T?>> GetFromJsonAsync<T>(string uri, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new());
    
    Task<Maybe<Fault>> PostAsync<TResource>(string uri, TResource resource, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new()) where TResource : Resource;
    
    Task<Maybe<Fault>> PutAsync<TResource>(string uri, TResource resource, Action<HttpRequestMessage>? requestConfiguration = null, CancellationToken cancellationToken = new()) where TResource : Resource;

    Task<Result<HttpResponseMessage>> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken);
}