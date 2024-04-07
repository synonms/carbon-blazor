namespace Synonms.CarbonBlazor.Enumerations;

public enum AlignItems
{
    /// Stretch to fill the container (still respect min-width/max-width)
    Stretch = 0,
    /// Items are placed at the start of the cross axis. The difference between these is subtle, and is about respecting the flex-direction rules or the writing-mode rules.
    FlexStart,
    /// Items are placed at the end of the cross axis. The difference again is subtle and is about respecting flex-direction rules vs. writing-mode rules.
    FlexEnd,
    /// Items are centered in the cross-axis
    Center,
    /// Items are aligned such as their baselines align
    Baseline,
    FirsBaseline,
    LastBaseline,
    /// Items are placed at the start of the cross axis. The difference between these is subtle, and is about respecting the flex-direction rules or the writing-mode rules.
    Start,
    /// Items are placed at the end of the cross axis. The difference again is subtle and is about respecting flex-direction rules vs. writing-mode rules.
    End,
    /// Items are placed at the start of the cross axis. The difference between these is subtle, and is about respecting the flex-direction rules or the writing-mode rules.
    SelfStart,
    /// Items are placed at the end of the cross axis. The difference again is subtle and is about respecting flex-direction rules vs. writing-mode rules.
    SelfEnd
}

public static class AlignItemsMapper
{
    public static string ToStyle(AlignItems alignItems) =>
        "align-items:" 
        + alignItems switch
        {
            AlignItems.Stretch => "stretch",
            AlignItems.FlexStart => "flex-start",
            AlignItems.FlexEnd => "flex-end",
            AlignItems.Center => "center",
            AlignItems.Baseline => "baseline",
            AlignItems.FirsBaseline => "first baseline",
            AlignItems.LastBaseline => "last baseline",
            AlignItems.Start => "start",
            AlignItems.End => "end",
            AlignItems.SelfStart => "self-start",
            AlignItems.SelfEnd => "self-end",
            _ => string.Empty
        }
        + ";";
}