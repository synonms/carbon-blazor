namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorButtonSize
{
    Medium = 0,
    Small,
    LargeProductive,
    LargeExpressive,
    ExtraLarge,
    ExtraExtraLarge
}

public static class CarbonBlazorButtonSizeMapper
{
    public static string ToClass(CarbonBlazorButtonSize size) => size switch
    {
        CarbonBlazorButtonSize.Small => "small",
        CarbonBlazorButtonSize.Medium => "medium",
        CarbonBlazorButtonSize.LargeProductive => "large-productive",
        CarbonBlazorButtonSize.LargeExpressive => "large-expressive",
        CarbonBlazorButtonSize.ExtraLarge => "extra-large",
        CarbonBlazorButtonSize.ExtraExtraLarge => "extra-extra-large",
        _ => string.Empty
    };
}