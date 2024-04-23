using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorModalSize
{
    Medium = 0,
    ExtraSmall,
    Small,
    Large
}

public static class CarbonBlazorModalSizeMapper
{
    public static string ToClass(CarbonBlazorModalSize size) => size switch
    {
        CarbonBlazorModalSize.ExtraSmall => CssClasses.Prefix + "modal-panel-xs",
        CarbonBlazorModalSize.Small => CssClasses.Prefix + "modal-panel-s",
        CarbonBlazorModalSize.Medium => CssClasses.Prefix + "modal-panel-m",
        CarbonBlazorModalSize.Large => CssClasses.Prefix + "modal-panel-l",
        _ => string.Empty
    };
}