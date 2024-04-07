using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorButtonSize
{
    Medium = 0,
    Small,
    Large,
    ExtraLarge
}

public static class CarbonBlazorButtonSizeMapper
{
    public static string ToClass(CarbonBlazorButtonSize size) => size switch
    {
        CarbonBlazorButtonSize.Medium => CssClasses.Prefix + "btn-m",
        CarbonBlazorButtonSize.Small => CssClasses.Prefix + "btn-s",
        CarbonBlazorButtonSize.Large => CssClasses.Prefix + "btn-l",
        CarbonBlazorButtonSize.ExtraLarge => CssClasses.Prefix + "btn-xl",
        _ => string.Empty
    };
}