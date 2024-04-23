using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Synonms.CarbonBlazor.Serialisation;

namespace Synonms.CarbonBlazor.Client;

public class IonCarbonBlazorHttpClient : CarbonBlazorHttpClient
{
    public IonCarbonBlazorHttpClient(IAccessTokenProvider tokenProvider, HttpClient httpClient)
        : base(httpClient, IonSerialiser.JsonSerializerOptions, client => RequestAuthToken(tokenProvider, client))
    {
    }
}