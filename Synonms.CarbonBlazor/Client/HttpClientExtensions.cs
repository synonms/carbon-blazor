using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Synonms.Functional;
using Synonms.RestEasy.Core.Infrastructure;

namespace Synonms.CarbonBlazor.Client;

public static class HttpClientExtensions
{
    public static async Task<Result<HttpClient>> WithAccessToken(this HttpClient httpClient, IAccessTokenProvider accessTokenProvider)
    {
        AccessTokenResult requestToken = await accessTokenProvider.RequestAccessToken();
        
        if (requestToken.TryGetToken(out AccessToken? token) is false)
        {
            return new AuthorisationFault("Unable to retrieve access token for HttpClient.");
        }

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
        
        return httpClient;
    }
}