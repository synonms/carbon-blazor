namespace Synonms.CarbonBlazor.Models;

public class CheckBoxItem
{
    public CheckBoxItem(string label, string value)
    {
        Label = label;
        Value = value;
    }

    public string Label { get; }
    
    public string Value { get; }

    public string Id { get; init;  } = Guid.NewGuid().ToString();

    public static CheckBoxItem Create(string value) => new(value, value);
    public static CheckBoxItem Create(string label, string value) => new(label, value);
}