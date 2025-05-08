namespace Synonms.CarbonBlazor.Models;

public class ContainedListGroup
{
    public ContainedListGroup(string text, IEnumerable<ContainedListItem> items)
    {
        Text = text;
        Items = items;
    }

    public string Text { get; }

    public IEnumerable<ContainedListItem> Items { get; }
}