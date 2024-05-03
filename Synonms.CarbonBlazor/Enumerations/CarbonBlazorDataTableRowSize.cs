namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorDataTableRowSize
{
    Medium = 0,
    ExtraSmall,
    Small,
    Large,
    ExtraLarge
}

public static class CarbonBlazorDataTableRowSizeMapper
{
    public static string ToClass(CarbonBlazorDataTableRowSize rowSize) => rowSize switch
    {
        CarbonBlazorDataTableRowSize.ExtraSmall => "extra-small",
        CarbonBlazorDataTableRowSize.Small => "small",
        CarbonBlazorDataTableRowSize.Medium => "medium",
        CarbonBlazorDataTableRowSize.Large => "large",
        CarbonBlazorDataTableRowSize.ExtraLarge => "extra-large",
        _ => string.Empty
    };
}