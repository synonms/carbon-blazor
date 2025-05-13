using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTextColour
{
    Primary = 0,
    Secondary,
    Disabled,
    Error,
    Helper,
    Inverse,
    OnColour,
    OnColourDisabled,
    Placeholder
}

public static class CarbonBlazorTextColourMapper
{
    public static string ToClass(CarbonBlazorTextColour colour) => colour switch
    {
        CarbonBlazorTextColour.Primary => "primary",
        CarbonBlazorTextColour.Secondary => "secondary",
        CarbonBlazorTextColour.Disabled => "disabled",
        CarbonBlazorTextColour.Error => "error",
        CarbonBlazorTextColour.Helper => "helper",
        CarbonBlazorTextColour.Inverse => "inverse",
        CarbonBlazorTextColour.OnColour => "on-color",
        CarbonBlazorTextColour.OnColourDisabled => "on-color-disabled",
        CarbonBlazorTextColour.Placeholder => "placeholder",
        _ => "",
    };
}