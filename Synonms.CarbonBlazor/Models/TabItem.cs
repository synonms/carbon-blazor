using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class TabItem
{
    public TabItem(string label, CarbonBlazorIcon? icon = null)
    {
        Label = label;
        Icon = icon;
    }

    public string Label { get; }
    
    public CarbonBlazorIcon? Icon { get; }
    
    public static TabItem Create(string label, CarbonBlazorIcon? icon = null) => new(label, icon);
}