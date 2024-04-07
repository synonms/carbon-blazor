using Synonms.CarbonBlazor.Css;

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
        CarbonBlazorButtonDisplay.TextAndIcon => CssClasses.Prefix + "btn-text-and-icon",
        CarbonBlazorButtonDisplay.IconOnly => CssClasses.Prefix + "btn-icon-only",
        CarbonBlazorButtonDisplay.TextOnly => CssClasses.Prefix + "btn-text-only",
        _ => string.Empty
    };
}