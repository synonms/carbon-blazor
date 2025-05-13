namespace Synonms.CarbonBlazor.Models;

public class Progress
{
    public class StepArgs
    {
        public StepArgs(string title, string? label = null)
        {
            Title = title;
            Label = label;       
        }

        public string Title { get; }
        public string? Label { get; }
    }
    
    private List<ProgressStep> _steps;
    
    public Progress(params StepArgs[] steps)
    {
        _steps = steps.Select(args => new ProgressStep(args.Title, args.Label)).ToList();
        _steps.First().IsEnabled = true;
        _steps.First().Status = ProgressStep.ProgressStatus.Current;
    }
    
    public IEnumerable<ProgressStep> Steps => _steps;
    
    public bool IsComplete => _steps.All(step => step.Status == ProgressStep.ProgressStatus.Complete);

    public void NextStep()
    {
        if (_steps.Count == 0)
        {
            return;
        }
        
        for (int i = 0; i < _steps.Count; i++)
        {
            if (_steps[i].Status == ProgressStep.ProgressStatus.Current)
            {
                _steps[i].Status = ProgressStep.ProgressStatus.Complete;

                if (i < _steps.Count - 1)
                {
                    _steps[i + 1].Status = ProgressStep.ProgressStatus.Current;
                    return;
                }
            }
        }
    }
    
    public void PreviousStep()
    {
        if (_steps.Count == 0)
        {
            return;
        }
        
        if (_steps.Last().Status == ProgressStep.ProgressStatus.Complete)
        {
            _steps.Last().Status = ProgressStep.ProgressStatus.Current;
            return;
        }
        
        for (int i = _steps.Count - 1; i >= 0; i--)
        {
            if (_steps[i].Status == ProgressStep.ProgressStatus.Current)
            {
                _steps[i].Status = ProgressStep.ProgressStatus.NotStarted;

                if (i > 0)
                {
                    _steps[i - 1].Status = ProgressStep.ProgressStatus.Current;
                    return;
                }
            }
        }
    }
}