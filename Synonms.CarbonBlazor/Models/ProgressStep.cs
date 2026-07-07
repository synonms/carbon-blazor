using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class ProgressStep
{
    public enum ProgressStatus
    {
        NotStarted = 0,
        Current,
        Complete
    }
    
    public ProgressStep(string label, string? helperText)
    {
        Label = label;
        HelperText = helperText;      
    }

    public CarbonBlazorIconType IconType => Status switch
    {
        ProgressStatus.NotStarted => CarbonBlazorIconType.CircleDash,
        ProgressStatus.Current => CarbonBlazorIconType.Incomplete,
        ProgressStatus.Complete => CarbonBlazorIconType.CheckmarkOutline,
        _ => throw new ArgumentOutOfRangeException()
    };

    public string Label { get; }
    
    public string? HelperText { get; }
    
    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;
    
    public bool IsEnabled { get; set; }
}