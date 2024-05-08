namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorTagColour
{
    Blue = 0,
    Black,
    White,
    CoolGray,
    Gray,
    WarmGray,
    Red,
    Magenta,
    Purple,
    Cyan,
    Teal,
    Green
}

public static class CarbonBlazorTagColourMapper
{
    public static string ToClass(CarbonBlazorTagColour tagColour) => tagColour switch
    {
        CarbonBlazorTagColour.Black => "black",
        CarbonBlazorTagColour.White => "white",
        CarbonBlazorTagColour.CoolGray => "cool-gray",
        CarbonBlazorTagColour.Gray => "gray",
        CarbonBlazorTagColour.WarmGray => "warm-gray",
        CarbonBlazorTagColour.Red => "red",
        CarbonBlazorTagColour.Magenta => "magenta",
        CarbonBlazorTagColour.Purple => "purple",
        CarbonBlazorTagColour.Blue => "blue",
        CarbonBlazorTagColour.Cyan => "cyan",
        CarbonBlazorTagColour.Teal => "teal",
        CarbonBlazorTagColour.Green => "green",
        _ => string.Empty
    };
}