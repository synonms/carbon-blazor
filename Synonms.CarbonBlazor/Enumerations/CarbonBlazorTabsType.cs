namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTabsType
{
    Default = 0,
    Contained
}

public static class CarbonBlazorTabsTypeMapper
{
    public static string ToClass(CarbonBlazorTabsType type) => type switch
    {
        CarbonBlazorTabsType.Contained => "contained",
        _ => string.Empty
    };
}