using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Components;

public class CarbonBlazorText : ComponentBase
{
    [Parameter]
    public CarbonBlazorTextType Type { get; set; } = CarbonBlazorTextType.Body;

    [Parameter]
    public WhiteSpace WhiteSpace { get; set; } = WhiteSpace.Normal;
    
    [Parameter]
    public bool IsExpressive { get; set; } = false;

    [Parameter]
    public string Class { get; set; } = string.Empty;

    [Parameter]
    public string Style { get; set; } = string.Empty;
    
    [Parameter]
    [EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        string cssClass = "cb-text " + CarbonBlazorTextTypeMapper.ToClass(Type, IsExpressive) + " " + Class;
        
        builder.OpenElement(0, CarbonBlazorTextTypeMapper.ToHtmlTag(Type));
        builder.AddAttribute(1, "class", cssClass);
        builder.AddAttribute(2, "style", WhiteSpaceMapper.ToStyle(WhiteSpace) + Style);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}