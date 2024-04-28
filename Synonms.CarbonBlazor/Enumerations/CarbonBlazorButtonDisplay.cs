namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorButtonDisplay
{
    TextOnly = 0,
    TextAndIcon,
    IconOnly
}

public static class CarbonBlazorButtonDisplayMapper
{
    public static string ToClass(CarbonBlazorButtonDisplay display) => display switch
    {
        CarbonBlazorButtonDisplay.TextOnly => "text",
        CarbonBlazorButtonDisplay.TextAndIcon => "text-icon",
        CarbonBlazorButtonDisplay.IconOnly => "icon",
        _ => string.Empty
    };
}