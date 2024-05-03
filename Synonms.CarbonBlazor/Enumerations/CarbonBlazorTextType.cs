namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTextType
{
    BodyCompact01,
    BodyCompact02,
    Body01,
    Body02,
    Heading01,
    Heading02,
    Heading03,
    Heading04,
    Heading05,
    Heading06,
    Heading07,
    HeadingCompact01,
    HeadingCompact02,
    HelperText01,
    HelperText02,
    Label01,
    Label02
}

public static class CarbonBlazorTextTypeMapper
{
    public static string ToClass(CarbonBlazorTextType textType) => textType switch
    {
        CarbonBlazorTextType.BodyCompact01 => "body-compact-01",
        CarbonBlazorTextType.BodyCompact02 => "body-compact-02",
        CarbonBlazorTextType.Body01 => "body-01",
        CarbonBlazorTextType.Body02 => "body-02",
        CarbonBlazorTextType.Heading01 => "heading-01",
        CarbonBlazorTextType.Heading02 => "heading-02",
        CarbonBlazorTextType.Heading03 => "heading-03",
        CarbonBlazorTextType.Heading04 => "heading-04",
        CarbonBlazorTextType.Heading05 => "heading-05",
        CarbonBlazorTextType.Heading06 => "heading-06",
        CarbonBlazorTextType.Heading07 => "heading-07",
        CarbonBlazorTextType.HeadingCompact01 => "heading-compact-01",
        CarbonBlazorTextType.HeadingCompact02 => "heading-compact-02",
        CarbonBlazorTextType.HelperText01 => "helper-text-01",
        CarbonBlazorTextType.HelperText02 => "helper-text-02",
        CarbonBlazorTextType.Label01 => "label-01",
        CarbonBlazorTextType.Label02 => "label-02",
        _ => string.Empty
    };
}