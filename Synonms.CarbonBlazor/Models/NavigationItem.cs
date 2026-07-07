using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class NavigationItem
{
    public NavigationItem(string text, string href)
    {
        Text = text;
        Href = href;
    }

    public string Text { get; }
    
    public string Href { get; }
    
    public CarbonBlazorIconType? Icon { get; init; }

    public static NavigationItem Create(string text, string href) => new(text, href);
    
    public static NavigationItem Create(CarbonBlazorIconType iconType, string text, string href) => new(text, href) { Icon = iconType };
}