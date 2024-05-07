namespace Synonms.CarbonBlazor.Enumerations;

public enum WhiteSpace
{
    Normal = 0,
    Nowrap,
    Pre,
    PreWrap,
    PreLine,
    BreakSpaces
}

public static class WhiteSpaceMapper
{
    public static string ToStyle(WhiteSpace whiteSpace) =>
        "white-space:" 
        + whiteSpace switch
        {
            WhiteSpace.Normal => "normal",
            WhiteSpace.Nowrap => "nowrap",
            WhiteSpace.Pre => "pre",
            WhiteSpace.PreWrap => "pre-wrap",
            WhiteSpace.PreLine => "pre-line",
            WhiteSpace.BreakSpaces => "break-spaces",
            _ => "normal"
        }
        + ";";
}