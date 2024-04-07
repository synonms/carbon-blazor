using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorSidePanelType
{
    Left = 0,
    Right
}

public static class CarbonBlazorPanelTypeMapper
{
    public static string ToClass(CarbonBlazorSidePanelType sidePanelType) => sidePanelType switch
    {
        CarbonBlazorSidePanelType.Left => CssClasses.Prefix + "side-panel-left",
        CarbonBlazorSidePanelType.Right => CssClasses.Prefix + "side-panel-right",
        _ => string.Empty
    };
}