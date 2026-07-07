using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class TabItem
{
    public TabItem(string label, CarbonBlazorIconType? icon = null)
    {
        Label = label;
        Icon = icon;
    }

    public string Label { get; }
    
    public CarbonBlazorIconType? Icon { get; }
    
    public static TabItem Create(string label, CarbonBlazorIconType? icon = null) => new(label, icon);
}