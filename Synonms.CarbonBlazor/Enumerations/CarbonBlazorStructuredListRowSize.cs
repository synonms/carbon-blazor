namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorStructuredListRowSize
{
    Normal = 0,
    Condensed
}

public static class CarbonBlazorStructuredListRowSizeMapper
{
    public static string ToClass(CarbonBlazorStructuredListRowSize rowSize) => rowSize switch
    {
        CarbonBlazorStructuredListRowSize.Condensed => "condensed",
        _ => string.Empty
    };
}