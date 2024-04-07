namespace Synonms.CarbonBlazor.Models;

public class BreadcrumbItem
{
    public BreadcrumbItem(string text, string path)
    {
        Text = text;
        Path = path;
    }

    public string Text { get; }

    public string Path { get; }
}