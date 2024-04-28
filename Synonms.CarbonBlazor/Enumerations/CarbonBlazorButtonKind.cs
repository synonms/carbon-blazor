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
}

public static class CarbonBlazorButtonKindMapper
{
    public static string ToClass(CarbonBlazorButtonKind buttonKind) => buttonKind switch
    {
        CarbonBlazorButtonKind.Primary => "primary",
        CarbonBlazorButtonKind.Secondary => "secondary",
        CarbonBlazorButtonKind.Tertiary => "tertiary",
        CarbonBlazorButtonKind.Danger => "danger",
        CarbonBlazorButtonKind.Ghost => "ghost",
        CarbonBlazorButtonKind.DangerTertiary => "danger-tertiary",
        CarbonBlazorButtonKind.DangerGhost => "danger-ghost",
        _ => string.Empty
    };
}