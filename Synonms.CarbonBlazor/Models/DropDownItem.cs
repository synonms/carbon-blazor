namespace Synonms.CarbonBlazor.Models;

public class DropDownItem<TValue> where TValue : notnull
{
    public DropDownItem(string label, TValue value)
    {
        Label = label;
        Value = value;
    }

    public string Label { get; }
    
    public TValue Value { get; }

    public static DropDownItem<TValue> Create(TValue value) => new(value.ToString()!, value);
    public static DropDownItem<TValue> Create(string label, TValue value) => new(label, value);
}