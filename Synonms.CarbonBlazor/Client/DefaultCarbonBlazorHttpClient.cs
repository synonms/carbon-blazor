using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Synonms.RestEasy.Core.Serialisation;
using Synonms.RestEasy.Core.Serialisation.Default;

namespace Synonms.CarbonBlazor.Client;

public class DefaultCarbonBlazorHttpClient : CarbonBlazorHttpClient
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { 
            new DateOnlyJsonConverter(),
            new OptionalDateOnlyJsonConverter(),
            new TimeOnlyJsonConverter(),
            new OptionalTimeOnlyJsonConverter(),
            new DefaultCustomJsonConverterFactory(),
            new DefaultLinkJsonConverter(),
            new DefaultFormDocumentJsonConverter(),
            new DefaultFormFieldJsonConverter(),
            new DefaultPaginationJsonConverter(),
            new DefaultErrorCollectionDocumentJsonConverter(),
            new DefaultErrorJsonConverter()
        }
    };

    public DefaultCarbonBlazorHttpClient(IAccessTokenProvider tokenProvider, HttpClient httpClient)
        : base(httpClient, JsonSerializerOptions, client => RequestAuthToken(tokenProvider, client))
    {
    }
}