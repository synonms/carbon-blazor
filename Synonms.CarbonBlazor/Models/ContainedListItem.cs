using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class ContainedListItem
{
    public ContainedListItem(string text)
    {
        Text = text;
    }
    
    public string Text { get; }
    
    public CarbonBlazorIcon? Icon { get; set; }
}