namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorMenuItemSize
{
    ExtraSmall,
    Small,
    Medium,
    Large
}

public static class CarbonBlazorMenuItemSizeMapper
{
    public static string ToClass(CarbonBlazorMenuItemSize size) => size switch
    {
        CarbonBlazorMenuItemSize.ExtraSmall => "extra-small",
        CarbonBlazorMenuItemSize.Small => "small",
        CarbonBlazorMenuItemSize.Medium => "medium",
        CarbonBlazorMenuItemSize.Large => "large",
        _ => string.Empty
    };
}
