using Microsoft.JSInterop;

namespace Synonms.CarbonBlazor.JavaScript;

public static class JsRuntimeExtensions
{
    public static ValueTask ClickAsync(this IJSRuntime jsRuntime, string elementId)
    {
        return jsRuntime.InvokeVoidAsync("clickElementById", elementId);
    }
}