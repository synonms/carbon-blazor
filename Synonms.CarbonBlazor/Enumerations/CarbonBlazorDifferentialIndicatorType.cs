namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorDifferentialIndicatorType
{
    Neutral = 0,
    CaretUp,
    CaretDown,
    ArrowUp,
    ArrowDown
}

public static class CarbonBlazorDifferentialIndicatorTypeMapper
{
    public static CarbonBlazorIcon ToIcon(CarbonBlazorDifferentialIndicatorType type) => type switch
    {
        CarbonBlazorDifferentialIndicatorType.CaretUp => CarbonBlazorIcon.CaretUp,
        CarbonBlazorDifferentialIndicatorType.CaretDown => CarbonBlazorIcon.CaretDown,
        CarbonBlazorDifferentialIndicatorType.ArrowUp => CarbonBlazorIcon.ArrowUpRight,
        CarbonBlazorDifferentialIndicatorType.ArrowDown => CarbonBlazorIcon.ArrowDownRight,
        _ => CarbonBlazorIcon.HorizontalLineSolid
    };
    
    public static string ToClass(CarbonBlazorDifferentialIndicatorType type) => type switch
    {
        CarbonBlazorDifferentialIndicatorType.CaretUp => "green",
        CarbonBlazorDifferentialIndicatorType.CaretDown => "red",
        CarbonBlazorDifferentialIndicatorType.ArrowUp => "green",
        CarbonBlazorDifferentialIndicatorType.ArrowDown => "red",
        _ => "blue"
    };
}