namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTextType
{
    Code,
    Label,
    HelperText,
    Legal,
    BodyCompact,
    Body,
    HeadingCompact,
    Heading,
    Heading03,
    Heading04,
    Heading05,
    Heading06,
    Heading07,
    FluidParagraph,
    FluidQuotation01,
    FluidQuotation02,
    FluidDisplay01,
    FluidDisplay02,
    FluidDisplay03,
    FluidDisplay04
}

public static class CarbonBlazorTextTypeMapper
{
    public static string ToClass(CarbonBlazorTextType textType, bool isExpressive) => textType switch
    {
        CarbonBlazorTextType.Code => "code-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.Label => "label-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.HelperText => "helper-text-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.Legal => "legal-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.BodyCompact => "body-compact-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.Body => "body-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.HeadingCompact => "heading-compact-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.Heading => "heading-" + (isExpressive ? "02" : "01"),
        CarbonBlazorTextType.Heading03 => (isExpressive ? "fluid-" : string.Empty) + "heading-03",
        CarbonBlazorTextType.Heading04 => (isExpressive ? "fluid-" : string.Empty) + "heading-04",
        CarbonBlazorTextType.Heading05 => (isExpressive ? "fluid-" : string.Empty) + "heading-05",
        CarbonBlazorTextType.Heading06 => (isExpressive ? "fluid-" : string.Empty) + "heading-06",
        CarbonBlazorTextType.Heading07 => "heading-07",
        CarbonBlazorTextType.FluidParagraph => "fluid-paragraph-01",
        CarbonBlazorTextType.FluidQuotation01 => "fluid-quotation-01",
        CarbonBlazorTextType.FluidQuotation02 => "fluid-quotation-02",
        CarbonBlazorTextType.FluidDisplay01 => "fluid-display-01",
        CarbonBlazorTextType.FluidDisplay02 => "fluid-display-02",
        CarbonBlazorTextType.FluidDisplay03 => "fluid-display-03",
        CarbonBlazorTextType.FluidDisplay04 => "fluid-display-04",
        _ => string.Empty
    };
    
    public static string ToHtmlTag(CarbonBlazorTextType textType) => textType switch
    {
        CarbonBlazorTextType.Code => "code",
        CarbonBlazorTextType.Label => "label",
        CarbonBlazorTextType.HelperText => "span",
        CarbonBlazorTextType.Legal => "span",
        CarbonBlazorTextType.BodyCompact => "p",
        CarbonBlazorTextType.Body => "p",
        CarbonBlazorTextType.HeadingCompact => "h2",
        CarbonBlazorTextType.Heading => "h1",
        CarbonBlazorTextType.Heading03 => "h3",
        CarbonBlazorTextType.Heading04 => "h4",
        CarbonBlazorTextType.Heading05 => "h5",
        CarbonBlazorTextType.Heading06 => "h6",
        CarbonBlazorTextType.Heading07 => "h7",
        CarbonBlazorTextType.FluidParagraph => "p",
        CarbonBlazorTextType.FluidQuotation01 => "blockquote",
        CarbonBlazorTextType.FluidQuotation02 => "blockquote",
        CarbonBlazorTextType.FluidDisplay01 => "span",
        CarbonBlazorTextType.FluidDisplay02 => "span",
        CarbonBlazorTextType.FluidDisplay03 => "span",
        CarbonBlazorTextType.FluidDisplay04 => "span",
        _ => string.Empty
    };
}