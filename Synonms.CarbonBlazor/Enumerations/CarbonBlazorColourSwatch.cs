namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorColourSwatch
{
    Unspecified = 0,
    Swatch10,
    Swatch20,
    Swatch30,
    Swatch40,
    Swatch50,
    Swatch60,
    Swatch70,
    Swatch80,
    Swatch90,
    Swatch100
}

public static class CarbonBlazorColourSwatchMapper
{
    public static string ToClass(CarbonBlazorColourSwatch colourSwatch) => colourSwatch switch
    {
        CarbonBlazorColourSwatch.Swatch10 => "10",
        CarbonBlazorColourSwatch.Swatch20 => "20",
        CarbonBlazorColourSwatch.Swatch30 => "30",
        CarbonBlazorColourSwatch.Swatch40 => "40",
        CarbonBlazorColourSwatch.Swatch50 => "50",
        CarbonBlazorColourSwatch.Swatch60 => "60",
        CarbonBlazorColourSwatch.Swatch70 => "70",
        CarbonBlazorColourSwatch.Swatch80 => "80",
        CarbonBlazorColourSwatch.Swatch90 => "90",
        CarbonBlazorColourSwatch.Swatch100 => "100",
        _ => string.Empty
    };
}