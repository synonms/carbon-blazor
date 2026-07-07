namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorIndicatorSize
{
    Small,
    Large
}

public static class CarbonBlazorIndicatorSizeMapper
{
    public static string ToClass(CarbonBlazorIndicatorSize size) => size switch
    {
        CarbonBlazorIndicatorSize.Small => "small",
        CarbonBlazorIndicatorSize.Large => "large",
        _ => string.Empty
    };
}