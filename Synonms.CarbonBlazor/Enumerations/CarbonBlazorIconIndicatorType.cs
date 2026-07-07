namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorIconIndicatorType
{
    Unknown = 0,
    Undefined,
    Failed,
    CautionMajor,
    CautionMinor,
    Succeeded,
    Normal,
    InProgress,
    Incomplete,
    NotStarted,
    Pending,
    Informative
}

public static class CarbonBlazorIconIndicatorTypeMapper
{
    public static CarbonBlazorIconType ToIcon(CarbonBlazorIconIndicatorType type) => type switch
    {
        CarbonBlazorIconIndicatorType.Undefined => CarbonBlazorIconType.UndefinedFilled,
        CarbonBlazorIconIndicatorType.Failed => CarbonBlazorIconType.ErrorFilled,
        CarbonBlazorIconIndicatorType.CautionMajor => CarbonBlazorIconType.WarningAltInvertedFilled,
        CarbonBlazorIconIndicatorType.CautionMinor => CarbonBlazorIconType.WarningAltFilled,
        CarbonBlazorIconIndicatorType.Succeeded => CarbonBlazorIconType.CheckmarkFilled,
        CarbonBlazorIconIndicatorType.Normal => CarbonBlazorIconType.CheckmarkOutline,
        CarbonBlazorIconIndicatorType.InProgress => CarbonBlazorIconType.InProgress,
        CarbonBlazorIconIndicatorType.Incomplete => CarbonBlazorIconType.Incomplete,
        CarbonBlazorIconIndicatorType.NotStarted => CarbonBlazorIconType.CircleDash,
        CarbonBlazorIconIndicatorType.Pending => CarbonBlazorIconType.PendingFilled,
        CarbonBlazorIconIndicatorType.Informative => CarbonBlazorIconType.InformationSquareFilled,
        _ => CarbonBlazorIconType.UnknownFilled
    };
    
    public static string ToClass(CarbonBlazorIconIndicatorType type) => type switch
    {
        CarbonBlazorIconIndicatorType.Undefined => "purple",
        CarbonBlazorIconIndicatorType.Failed => "red",
        CarbonBlazorIconIndicatorType.CautionMajor => "orange",
        CarbonBlazorIconIndicatorType.CautionMinor => "yellow",
        CarbonBlazorIconIndicatorType.Succeeded => "green",
        CarbonBlazorIconIndicatorType.Normal => "blue",
        CarbonBlazorIconIndicatorType.InProgress => "blue",
        CarbonBlazorIconIndicatorType.Incomplete => "blue",
        CarbonBlazorIconIndicatorType.NotStarted => "gray",
        CarbonBlazorIconIndicatorType.Pending => "gray",
        CarbonBlazorIconIndicatorType.Informative => "blue",
        _ => "gray"
    };
}