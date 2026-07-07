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
    public static CarbonBlazorIcon ToIcon(CarbonBlazorIconIndicatorType type) => type switch
    {
        CarbonBlazorIconIndicatorType.Undefined => CarbonBlazorIcon.UndefinedFilled,
        CarbonBlazorIconIndicatorType.Failed => CarbonBlazorIcon.ErrorFilled,
        CarbonBlazorIconIndicatorType.CautionMajor => CarbonBlazorIcon.WarningAltInvertedFilled,
        CarbonBlazorIconIndicatorType.CautionMinor => CarbonBlazorIcon.WarningAltFilled,
        CarbonBlazorIconIndicatorType.Succeeded => CarbonBlazorIcon.CheckmarkFilled,
        CarbonBlazorIconIndicatorType.Normal => CarbonBlazorIcon.CheckmarkOutline,
        CarbonBlazorIconIndicatorType.InProgress => CarbonBlazorIcon.InProgress,
        CarbonBlazorIconIndicatorType.Incomplete => CarbonBlazorIcon.Incomplete,
        CarbonBlazorIconIndicatorType.NotStarted => CarbonBlazorIcon.CircleDash,
        CarbonBlazorIconIndicatorType.Pending => CarbonBlazorIcon.PendingFilled,
        CarbonBlazorIconIndicatorType.Informative => CarbonBlazorIcon.InformationSquareFilled,
        _ => CarbonBlazorIcon.UnknownFilled
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