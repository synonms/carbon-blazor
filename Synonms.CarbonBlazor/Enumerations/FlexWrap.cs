namespace Synonms.CarbonBlazor.Enumerations;

public enum FlexWrap
{
    /// All flex items will be on one line
    NoWrap = 0,
    /// Flex items will wrap onto multiple lines, from top to bottom.
    Wrap,
    /// Flex items will wrap onto multiple lines from bottom to top. 
    WrapReverse
}

public static class FlexWrapMapper
{
    public static string ToStyle(FlexWrap wrap) => 
        "flex-wrap:"
        + wrap switch
        {
            FlexWrap.NoWrap => "nowrap",
            FlexWrap.Wrap => "wrap",
            FlexWrap.WrapReverse => "wrap-reverse",
            _ => string.Empty
        }
        + ";";
}