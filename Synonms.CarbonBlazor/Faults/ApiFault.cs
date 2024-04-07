using Synonms.Functional;
using Synonms.RestEasy.Core.Schema.Errors;

namespace Synonms.CarbonBlazor.Faults;

public class ApiFault : Fault
{
    public ApiFault(IEnumerable<Error> errors, params object?[] arguments) 
        : this(errors, string.Empty, new FaultSource(), arguments)
    {
    }
    
    public ApiFault(IEnumerable<Error> errors, string detail, params object?[] arguments) 
        : this(errors, detail, new FaultSource(), arguments)
    {
    }
    
    public ApiFault(string detail, params object?[] arguments) 
        : this(detail, new FaultSource(), arguments)
    {
    }

    public ApiFault(IEnumerable<Error> errors, string detail, FaultSource source, params object?[] arguments) 
        : base(nameof(ApiFault), "API Fault", detail, source, arguments)
    {
        Errors = errors;
    }

    public ApiFault(string detail, FaultSource source, params object?[] arguments) 
        : base(nameof(ApiFault), "API Fault", detail, source, arguments)
    {
        Errors = Enumerable.Empty<Error>();
    }

    public IEnumerable<Error> Errors { get; }
}