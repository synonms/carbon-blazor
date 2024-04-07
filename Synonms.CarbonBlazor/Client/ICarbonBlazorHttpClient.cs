using Synonms.Functional;
using Synonms.RestEasy.Core.Schema.Forms;
using Synonms.RestEasy.Core.Schema.Resources;

namespace Synonms.CarbonBlazor.Client;

public interface ICarbonBlazorHttpClient
{
    Task<Result<FormDocument>> CreateFormAsync(string uri, CancellationToken cancellationToken);

    Task<Maybe<Fault>> DeleteAsync(string uri, CancellationToken cancellationToken);

    Task<Result<FormDocument>> EditFormAsync(string uri, CancellationToken cancellationToken);
    
    Task<Result<ResourceCollectionDocument<TResource>>> GetAllAsync<TResource>(string uri, CancellationToken cancellationToken) where TResource : Resource;
    
    Task<Result<ResourceDocument<TResource>>> GetByIdAsync<TResource>(string uri, CancellationToken cancellationToken) where TResource : Resource;

    Task<Result<T?>> GetFromJsonAsync<T>(string uri, CancellationToken cancellationToken);
    
    Task<Maybe<Fault>> PostAsync<TResource>(string uri, TResource resource, CancellationToken cancellationToken) where TResource : Resource;
    
    Task<Maybe<Fault>> PutAsync<TResource>(string uri, TResource resource, CancellationToken cancellationToken) where TResource : Resource;

    Task<Result<HttpResponseMessage>> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken);
}