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
        CarbonBlazorModalSize.ExtraSmall => "extra-small",
        CarbonBlazorModalSize.Small => "small",
        CarbonBlazorModalSize.Medium => "medium",
        CarbonBlazorModalSize.Large => "large",
        _ => string.Empty
    };
}