namespace Synonms.CarbonBlazor.Enumerations;

public enum CarbonBlazorLayer
{
    Base,
    One,
    Two,
    Three
}

public static class CarbonBlazorLayerMapper
{
    public static string ToClass(CarbonBlazorLayer layer) => layer switch
    {
        CarbonBlazorLayer.Base => "layer-00",
        CarbonBlazorLayer.One => "layer-01",
        CarbonBlazorLayer.Two => "layer-02",
        CarbonBlazorLayer.Three => "layer-03",
        _ => string.Empty
    };
}