namespace Synonms.CarbonBlazor.Css;

public static class CssClasses
{
    public const string Prefix = "cb-";

    public static string Concatenate(params string[] classes) =>
        string.Join(" ", classes);
}