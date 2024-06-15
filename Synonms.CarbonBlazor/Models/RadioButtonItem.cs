namespace Synonms.CarbonBlazor.Models;

public class RadioButtonItem
{
    public RadioButtonItem(string label, string value)
    {
        Label = label;
        Value = value;
    }

    public string Label { get; }
    
    public string Value { get; }

    public string Id { get; init;  } = Guid.NewGuid().ToString();

    public static RadioButtonItem Create(string value) => new(value, value);
    public static RadioButtonItem Create(string label, string value) => new(label, value);
}