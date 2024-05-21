namespace Synonms.CarbonBlazor.Models;

public class SelectItem<TValue> where TValue : notnull
{
    public SelectItem(string label, TValue value)
    {
        Label = label;
        Value = value;
    }

    public string Label { get; }
    
    public TValue Value { get; }

    public static SelectItem<TValue> Create(TValue value) => new(value.ToString()!, value);
    public static SelectItem<TValue> Create(string label, TValue value) => new(label, value);
}