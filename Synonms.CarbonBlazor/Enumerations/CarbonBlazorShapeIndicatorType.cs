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
    public static CarbonBlazorIconType ToIcon(CarbonBlazorShapeIndicatorType type) => type switch
    {
        CarbonBlazorShapeIndicatorType.Undefined => CarbonBlazorIconType.DiamondFill,
        CarbonBlazorShapeIndicatorType.Failed => CarbonBlazorIconType.Critical,
        CarbonBlazorShapeIndicatorType.Critical => CarbonBlazorIconType.CriticalSeverity,
        CarbonBlazorShapeIndicatorType.High => CarbonBlazorIconType.Caution,
        CarbonBlazorShapeIndicatorType.Medium => CarbonBlazorIconType.DiamondFill,
        CarbonBlazorShapeIndicatorType.Low => CarbonBlazorIconType.LowSeverity,
        CarbonBlazorShapeIndicatorType.Cautious => CarbonBlazorIconType.Caution,
        CarbonBlazorShapeIndicatorType.Stable => CarbonBlazorIconType.CircleFill,
        CarbonBlazorShapeIndicatorType.Informative => CarbonBlazorIconType.SquareFill,
        CarbonBlazorShapeIndicatorType.Incomplete => CarbonBlazorIconType.Incomplete,
        CarbonBlazorShapeIndicatorType.Draft => CarbonBlazorIconType.CircleStroke,
        _ => CarbonBlazorIconType.CircleStroke
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