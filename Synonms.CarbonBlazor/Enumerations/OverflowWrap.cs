namespace Synonms.CarbonBlazor.Enumerations;

public enum OverflowWrap
{
     Normal = 0,
     Anywhere,
     BreakWord
}

public static class OverflowWrapMapper
{
     public static string ToStyle(OverflowWrap wrap) => 
          "overflow-wrap:"
          + wrap switch
          {
               OverflowWrap.Normal => "normal",
               OverflowWrap.Anywhere => "anywhere",
               OverflowWrap.BreakWord => "break-word",
               _ => string.Empty
          }
          + ";";
}