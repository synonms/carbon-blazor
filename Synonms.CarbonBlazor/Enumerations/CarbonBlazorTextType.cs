using Synonms.CarbonBlazor.Css;

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
    Label02,
    Error01,
    Error02
}

public static class CarbonBlazorTextTypeMapper
{
    public static string ToClass(CarbonBlazorTextType textType) => textType switch
    {
        CarbonBlazorTextType.BodyCompact01 => CssClasses.Prefix + "text-body-compact-01",
        CarbonBlazorTextType.BodyCompact02 => CssClasses.Prefix + "text-body-compact-02",
        CarbonBlazorTextType.Body01 => CssClasses.Prefix + "text-body-01",
        CarbonBlazorTextType.Body02 => CssClasses.Prefix + "text-body-02",
        CarbonBlazorTextType.Heading01 => CssClasses.Prefix + "text-heading-01",
        CarbonBlazorTextType.Heading02 => CssClasses.Prefix + "text-heading-02",
        CarbonBlazorTextType.Heading03 => CssClasses.Prefix + "text-heading-03",
        CarbonBlazorTextType.Heading04 => CssClasses.Prefix + "text-heading-04",
        CarbonBlazorTextType.Heading05 => CssClasses.Prefix + "text-heading-05",
        CarbonBlazorTextType.Heading06 => CssClasses.Prefix + "text-heading-06",
        CarbonBlazorTextType.Heading07 => CssClasses.Prefix + "text-heading-07",
        CarbonBlazorTextType.HeadingCompact01 => CssClasses.Prefix + "text-heading-compact-01",
        CarbonBlazorTextType.HeadingCompact02 => CssClasses.Prefix + "text-heading-compact-02",
        CarbonBlazorTextType.HelperText01 => CssClasses.Prefix + "text-helper-text-01",
        CarbonBlazorTextType.HelperText02 => CssClasses.Prefix + "text-helper-text-02",
        CarbonBlazorTextType.Label01 => CssClasses.Prefix + "text-label-01",
        CarbonBlazorTextType.Label02 => CssClasses.Prefix + "text-label-02",
        CarbonBlazorTextType.Error01 => CssClasses.Prefix + "text-error-01",
        CarbonBlazorTextType.Error02 => CssClasses.Prefix + "text-error-02",
        _ => string.Empty
    };
}