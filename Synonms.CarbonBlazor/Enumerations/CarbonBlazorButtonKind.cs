using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorButtonKind
{
    Primary,
    Secondary,
    Tertiary,
    Danger,
    DangerTertiary,
    DangerGhost,
    Ghost,
    Header,
    Input,
    Body
}

public static class CarbonBlazorButtonKindMapper
{
    public static string ToClass(CarbonBlazorButtonKind buttonKind) => buttonKind switch
    {
        CarbonBlazorButtonKind.Primary => CssClasses.Prefix + "btn-primary",
        CarbonBlazorButtonKind.Secondary => CssClasses.Prefix + "btn-secondary",
        CarbonBlazorButtonKind.Tertiary => CssClasses.Prefix + "btn-tertiary",
        CarbonBlazorButtonKind.Danger => CssClasses.Prefix + "btn-danger",
        CarbonBlazorButtonKind.DangerTertiary => CssClasses.Prefix + "btn-danger-tertiary",
        CarbonBlazorButtonKind.DangerGhost => CssClasses.Prefix + "btn-danger-ghost",
        CarbonBlazorButtonKind.Ghost => CssClasses.Prefix + "btn-ghost",
        CarbonBlazorButtonKind.Header => CssClasses.Prefix + "btn-header",
        CarbonBlazorButtonKind.Input => CssClasses.Prefix + "btn-input",
        CarbonBlazorButtonKind.Body => CssClasses.Prefix + "btn-body",
        _ => string.Empty
    };
}