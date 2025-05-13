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

    public CarbonBlazorIcon Icon => Status switch
    {
        ProgressStatus.NotStarted => CarbonBlazorIcon.CircleDash,
        ProgressStatus.Current => CarbonBlazorIcon.Incomplete,
        ProgressStatus.Complete => CarbonBlazorIcon.CheckmarkOutline,
        _ => throw new ArgumentOutOfRangeException()
    };

    public string Label { get; }
    
    public string? HelperText { get; }
    
    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;
    
    public bool IsEnabled { get; set; }
}