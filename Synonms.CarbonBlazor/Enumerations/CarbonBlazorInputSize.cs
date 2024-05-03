namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorInputSize
{
    Medium = 0,
    Small,
    Large
}

public static class CarbonBlazorInputSizeMapper
{
    public static string ToClass(CarbonBlazorInputSize size) => size switch
    {
        CarbonBlazorInputSize.Small => "small",
        CarbonBlazorInputSize.Medium => "medium",
        CarbonBlazorInputSize.Large => "large",
        _ => string.Empty
    };
}