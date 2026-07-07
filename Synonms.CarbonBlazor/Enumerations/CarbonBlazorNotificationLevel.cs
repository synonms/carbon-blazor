namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorNotificationLevel
{
    Information = 0,
    Success,
    Warning,
    Error
}

public static class CarbonBlazorNotificationLevelMapper
{
    public static string ToClass(CarbonBlazorNotificationLevel level) => level switch
    {
        CarbonBlazorNotificationLevel.Information => "information",
        CarbonBlazorNotificationLevel.Success => "success",
        CarbonBlazorNotificationLevel.Warning => "warning",
        CarbonBlazorNotificationLevel.Error => "error",
        _ => string.Empty
    };
    
    public static CarbonBlazorIconType ToIcon(CarbonBlazorNotificationLevel level) => level switch
    {
        CarbonBlazorNotificationLevel.Information => CarbonBlazorIconType.InformationFilled,
        CarbonBlazorNotificationLevel.Success => CarbonBlazorIconType.CheckmarkFilled,
        CarbonBlazorNotificationLevel.Warning => CarbonBlazorIconType.WarningFilled,
        CarbonBlazorNotificationLevel.Error => CarbonBlazorIconType.ErrorFilled,
        _ => CarbonBlazorIconType.InformationFilled
    };
}