namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorColourFamily
{
    Transparent = 0,
    White,
    CoolGray,
    Gray,
    WarmGray,
    Black,
    Red,
    Magenta,
    Purple,
    Blue,
    Cyan,
    Teal,
    Green
}

public static class CarbonBlazorColourFamilyMapper
{
    public static string ToClass(CarbonBlazorColourFamily colourFamily) => colourFamily switch
    {
        CarbonBlazorColourFamily.Transparent => "transparent",
        CarbonBlazorColourFamily.White => "white",
        CarbonBlazorColourFamily.CoolGray => "cool-gray",
        CarbonBlazorColourFamily.Gray => "gray",
        CarbonBlazorColourFamily.WarmGray => "warm-gray",
        CarbonBlazorColourFamily.Black => "black",
        CarbonBlazorColourFamily.Red => "red",
        CarbonBlazorColourFamily.Magenta => "magenta",
        CarbonBlazorColourFamily.Purple => "purple",
        CarbonBlazorColourFamily.Blue => "blue",
        CarbonBlazorColourFamily.Cyan => "cyan",
        CarbonBlazorColourFamily.Teal => "teal",
        CarbonBlazorColourFamily.Green => "green",
        _ => string.Empty
    };
}