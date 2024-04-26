namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorNotificationStyle
{
    LowContrast = 0,
    HighContrast
}

public static class CarbonBlazorNotificationStyleMapper
{
    public static string ToClass(CarbonBlazorNotificationStyle level) => level switch
    {
        CarbonBlazorNotificationStyle.LowContrast => "low-contrast",
        CarbonBlazorNotificationStyle.HighContrast => "high-contrast",
        _ => string.Empty
    };
}