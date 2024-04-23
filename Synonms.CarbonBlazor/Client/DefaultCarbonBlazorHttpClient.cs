using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Synonms.CarbonBlazor.Serialisation;

namespace Synonms.CarbonBlazor.Client;

public class DefaultCarbonBlazorHttpClient : CarbonBlazorHttpClient
{
    public DefaultCarbonBlazorHttpClient(IAccessTokenProvider tokenProvider, HttpClient httpClient)
        : base(httpClient, DefaultSerialiser.JsonSerializerOptions, client => RequestAuthToken(tokenProvider, client))
    {
    }
}