using Microsoft.AspNetCore.Components.Forms;

namespace Synonms.CarbonBlazor.Models;

public class ValidationOutcome
{
    public enum ValidationState
    {
        Unvalidated = 0,
        Valid,
        Warning,
        Error
    }
    
    private ValidationOutcome(FieldIdentifier fieldIdentifier, ValidationState state, string message)
    {
        FieldIdentifier = fieldIdentifier;
        State = state;
        Message = message;
    }
    
    public FieldIdentifier FieldIdentifier { get; }
    
    public ValidationState State { get; }
    
    public string Message { get; }

    public static ValidationOutcome Unvalidated(FieldIdentifier fieldIdentifier) => new(fieldIdentifier, ValidationState.Unvalidated, string.Empty);

    public static ValidationOutcome Valid(FieldIdentifier fieldIdentifier) => new(fieldIdentifier, ValidationState.Valid, string.Empty);
    
    public static ValidationOutcome Warning(FieldIdentifier fieldIdentifier, string message) => new(fieldIdentifier, ValidationState.Warning, message);
    
    public static ValidationOutcome Error(FieldIdentifier fieldIdentifier, string message) => new(fieldIdentifier, ValidationState.Error, message);

    public string ToCssClass() => State switch
    {
        ValidationState.Valid => "valid",
        ValidationState.Warning => "warning",
        ValidationState.Error => "error",
        _ => string.Empty
    };
}