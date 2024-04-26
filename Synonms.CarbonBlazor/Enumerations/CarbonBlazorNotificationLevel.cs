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
    
    public static CarbonBlazorIcon ToIcon(CarbonBlazorNotificationLevel level) => level switch
    {
        CarbonBlazorNotificationLevel.Information => CarbonBlazorIcon.InformationFilled,
        CarbonBlazorNotificationLevel.Success => CarbonBlazorIcon.CheckmarkFilled,
        CarbonBlazorNotificationLevel.Warning => CarbonBlazorIcon.WarningFilled,
        CarbonBlazorNotificationLevel.Error => CarbonBlazorIcon.ErrorFilled,
        _ => CarbonBlazorIcon.InformationFilled
    };
}