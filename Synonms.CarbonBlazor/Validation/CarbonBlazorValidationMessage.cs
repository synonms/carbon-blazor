using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Synonms.CarbonBlazor.Css;

namespace Synonms.CarbonBlazor.Validation;

public class CarbonBlazorValidationMessage : ComponentBase
{
    private List<ValidationOutcome> _filteredValidationOutcomes = [];

    [CascadingParameter]
    public IEnumerable<ValidationOutcome> ValidationOutcomes { get; set; } = [];

    [Parameter]
    [EditorRequired]
    public FieldIdentifier FieldIdentifier { get; set; } = default!;

    public ValidationOutcome.ValidationState ValidationState => _filteredValidationOutcomes.Any(x => x.State == ValidationOutcome.ValidationState.Error)
                ? ValidationOutcome.ValidationState.Error
                : _filteredValidationOutcomes.Any(x => x.State == ValidationOutcome.ValidationState.Warning)
                    ? ValidationOutcome.ValidationState.Warning
                    : ValidationOutcome.ValidationState.Valid;

    protected override void OnParametersSet()
    {
        _filteredValidationOutcomes = ValidationOutcomes.Where(x => x.FieldIdentifier.FieldName == FieldIdentifier.FieldName).ToList();
    }
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        foreach (ValidationOutcome validationOutcome in _filteredValidationOutcomes)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", CssClasses.Prefix + "validation-message " + validationOutcome.ToCssClass());
            builder.AddContent(2, validationOutcome.Message);
            builder.CloseElement();
        }
    }
}
