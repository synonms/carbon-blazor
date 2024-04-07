namespace Synonms.CarbonBlazor.Enumerations;

public enum JustifyContent
{
    /// Items are packed toward the start of the flex-direction.
    FlexStart = 0,
    /// Items are packed toward the end of the flex-direction.
    FlexEnd,
    /// Items are centered along the line
    Center,
    /// Items are evenly distributed in the line; first item is on the start line, last item on the end line
    SpaceBetween,
    /// Items are evenly distributed in the line with equal space around them. Note that visually the spaces aren’t equal, since all the items have equal space on both sides. The first item will have one unit of space against the container edge, but two units of space between the next item because that next item has its own spacing that applies.
    SpaceAround,
    /// Items are distributed so that the spacing between any two items (and the space to the edges) is equal.
    SpaceEvenly,
    /// Items are packed toward the start of the writing-mode direction.
    Start,
    /// Items are packed toward the end of the writing-mode direction.
    End,
    /// Items are packed toward left edge of the container, unless that doesn’t make sense with the flex-direction, then it behaves like start.
    Left,
    /// Items are packed toward right edge of the container, unless that doesn’t make sense with the flex-direction, then it behaves like end.
    Right
}

public static class JustifyContentMapper
{
    public static string ToStyle(JustifyContent direction) => 
        "justify-content:" 
        + direction switch
        {
            JustifyContent.FlexStart => "flex-start",
            JustifyContent.FlexEnd => "flex-end",
            JustifyContent.Center => "center",
            JustifyContent.SpaceBetween => "space-between",
            JustifyContent.SpaceAround => "space-around",
            JustifyContent.SpaceEvenly => "space-evenly",
            JustifyContent.Start => "start",
            JustifyContent.End => "end",
            JustifyContent.Left => "left",
            JustifyContent.Right => "right",
            _ => string.Empty
        }
        + ";";
}