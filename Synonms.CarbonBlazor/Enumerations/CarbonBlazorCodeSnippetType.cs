namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorCodeSnippetType
{
    Inline = 0,
    SingleLine,
    MultiLine
}

public static class CarbonBlazorCodeSnippetTypeMapper
{
    public static string ToClass(CarbonBlazorCodeSnippetType size) => size switch
    {
        CarbonBlazorCodeSnippetType.Inline => "inline",
        CarbonBlazorCodeSnippetType.SingleLine => "single-line",
        CarbonBlazorCodeSnippetType.MultiLine => "multi-line",
        _ => string.Empty
    };
}