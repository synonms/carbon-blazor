namespace Synonms.CarbonBlazor.Models;

public class TabItemList
{
    public event EventHandler<TabItem>? TabItemSelected;

    public TabItemList(List<TabItem> items)
    {
        Items = items;

        if (Items.Count > 0)
        {
            SelectTabItem(Items[0]);
        }
    }

    public List<TabItem> Items { get; }

    public TabItem? SelectedTabItem { get; private set; }

    public void SelectTabItem(TabItem item)
    {
        SelectedTabItem = item;
        TabItemSelected?.Invoke(this, item);
    }
    
    public static TabItemList Create(params TabItem[] items) => new(items.ToList());
}