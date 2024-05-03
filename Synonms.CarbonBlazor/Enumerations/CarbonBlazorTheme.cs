using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTheme
{
    White,
    Gray10,
    Gray90,
    Gray100
}

public static class CarbonBlazorThemeMapper
{
    public static string ToCssClass(CarbonBlazorTheme theme) => theme switch
    {
        CarbonBlazorTheme.White => CssClasses.Prefix + "theme-white",
        CarbonBlazorTheme.Gray10 => CssClasses.Prefix + "theme-gray-10",
        CarbonBlazorTheme.Gray90 => CssClasses.Prefix + "theme-gray-90",
        CarbonBlazorTheme.Gray100 => CssClasses.Prefix + "theme-gray-100",
        _ => ""
    };
}