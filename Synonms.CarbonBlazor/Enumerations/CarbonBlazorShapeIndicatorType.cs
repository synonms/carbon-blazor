namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorShapeIndicatorType
{
    Unknown = 0,
    Undefined,
    Failed,
    Critical,
    High,
    Medium,
    Low,
    Cautious,
    Stable,
    Informative,
    Incomplete,
    Draft
}

public static class CarbonBlazorShapeIndicatorTypeMapper
{
    public static CarbonBlazorIcon ToIcon(CarbonBlazorShapeIndicatorType type) => type switch
    {
        CarbonBlazorShapeIndicatorType.Undefined => CarbonBlazorIcon.DiamondFill,
        CarbonBlazorShapeIndicatorType.Failed => CarbonBlazorIcon.Critical,
        CarbonBlazorShapeIndicatorType.Critical => CarbonBlazorIcon.CriticalSeverity,
        CarbonBlazorShapeIndicatorType.High => CarbonBlazorIcon.Caution,
        CarbonBlazorShapeIndicatorType.Medium => CarbonBlazorIcon.DiamondFill,
        CarbonBlazorShapeIndicatorType.Low => CarbonBlazorIcon.LowSeverity,
        CarbonBlazorShapeIndicatorType.Cautious => CarbonBlazorIcon.Caution,
        CarbonBlazorShapeIndicatorType.Stable => CarbonBlazorIcon.CircleFill,
        CarbonBlazorShapeIndicatorType.Informative => CarbonBlazorIcon.SquareFill,
        CarbonBlazorShapeIndicatorType.Incomplete => CarbonBlazorIcon.Incomplete,
        CarbonBlazorShapeIndicatorType.Draft => CarbonBlazorIcon.CircleStroke,
        _ => CarbonBlazorIcon.CircleStroke
    };
    
    public static string ToClass(CarbonBlazorShapeIndicatorType type) => type switch
    {
        CarbonBlazorShapeIndicatorType.Undefined => "purple",
        CarbonBlazorShapeIndicatorType.Failed => "red",
        CarbonBlazorShapeIndicatorType.Critical => "red",
        CarbonBlazorShapeIndicatorType.High => "red",
        CarbonBlazorShapeIndicatorType.Medium => "orange",
        CarbonBlazorShapeIndicatorType.Low => "yellow",
        CarbonBlazorShapeIndicatorType.Cautious => "yellow",
        CarbonBlazorShapeIndicatorType.Stable => "green",
        CarbonBlazorShapeIndicatorType.Informative => "blue",
        CarbonBlazorShapeIndicatorType.Incomplete => "blue",
        CarbonBlazorShapeIndicatorType.Draft => "gray",
        _ => "gray"
    };
}