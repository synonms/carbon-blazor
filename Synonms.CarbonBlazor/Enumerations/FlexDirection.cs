namespace Synonms.CarbonBlazor.Enumerations;

public enum FlexDirection
{
    /// Left to right
    Row = 0,
    /// Right to left
    RowReverse,
    /// Top to bottom 
    Column,
    /// Bottom to top
    ColumnReverse
}

public static class FlexDirectionMapper
{
    public static string ToStyle(FlexDirection direction) =>
        "flex-direction:" 
        + direction switch
        {
            FlexDirection.Row => "row",
            FlexDirection.RowReverse => "row-reverse",
            FlexDirection.Column => "column",
            FlexDirection.ColumnReverse => "column-reverse",
            _ => string.Empty
        }
        + ";";
}