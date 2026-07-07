namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorIconSize
{
    Default = 0,
    Large
}

public static class CarbonBlazorIconSizeExtensions
{
    public static int ToPixels(this CarbonBlazorIconSize size) => size switch
    {
        CarbonBlazorIconSize.Large => 20,
        _ => 16
    };
}