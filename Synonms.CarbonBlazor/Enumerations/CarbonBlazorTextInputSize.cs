namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTextInputSize
{
    Medium = 0,
    Small,
    Large
}

public static class CarbonBlazorTextInputSizeMapper
{
    public static string ToClass(CarbonBlazorTextInputSize size) => size switch
    {
        CarbonBlazorTextInputSize.Small => "small",
        CarbonBlazorTextInputSize.Medium => "medium",
        CarbonBlazorTextInputSize.Large => "large",
        _ => string.Empty
    };
}