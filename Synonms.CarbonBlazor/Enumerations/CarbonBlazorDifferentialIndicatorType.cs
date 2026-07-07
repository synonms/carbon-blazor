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
    public static CarbonBlazorIconType ToIcon(CarbonBlazorDifferentialIndicatorType type) => type switch
    {
        CarbonBlazorDifferentialIndicatorType.CaretUp => CarbonBlazorIconType.CaretUp,
        CarbonBlazorDifferentialIndicatorType.CaretDown => CarbonBlazorIconType.CaretDown,
        CarbonBlazorDifferentialIndicatorType.ArrowUp => CarbonBlazorIconType.ArrowUpRight,
        CarbonBlazorDifferentialIndicatorType.ArrowDown => CarbonBlazorIconType.ArrowDownRight,
        _ => CarbonBlazorIconType.HorizontalLineSolid
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