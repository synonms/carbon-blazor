namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTagType
{
    ReadOnly = 0,
    Dismissible,
    Selectable,
    Operational
}

public static class CarbonBlazorTagTypeMapper
{
    public static string ToClass(CarbonBlazorTagType type) => type switch
    {
        CarbonBlazorTagType.ReadOnly => "read-only",
        CarbonBlazorTagType.Dismissible => "dismissible",
        CarbonBlazorTagType.Selectable => "selectable",
        CarbonBlazorTagType.Operational => "operational",
        _ => string.Empty
    };
}