using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Synonms.CarbonBlazor.Css;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Components;

public class CarbonBlazorText : ComponentBase
{
    [Parameter]
    public CarbonBlazorTextType Type { get; set; } = CarbonBlazorTextType.Body;

    [Parameter]
    public CarbonBlazorTextColour Colour { get; set; } = CarbonBlazorTextColour.Primary;
    
    [Parameter]
    public WhiteSpace WhiteSpace { get; set; } = WhiteSpace.Normal;

    [Parameter]
    public OverflowWrap? OverflowWrap { get; set; }

    [Parameter]
    public bool IsExpressive { get; set; }

    [Parameter]
    public string Class { get; set; } = string.Empty;

    [Parameter]
    public string Style { get; set; } = string.Empty;
    
    [Parameter]
    [EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        string baseClass = CssClasses.Prefix + "text";
        string colourClass = CarbonBlazorTextColourMapper.ToClass(Colour);
        string cssClass = CssClasses.Concatenate(baseClass, colourClass, CarbonBlazorTextTypeMapper.ToClass(Type, IsExpressive), Class);

        string whiteSpaceStyle = WhiteSpaceMapper.ToStyle(WhiteSpace);
        string overflowWrapStyle = OverflowWrap is null ? string.Empty : OverflowWrapMapper.ToStyle(OverflowWrap.Value);
        string style = string.Join(" ", [whiteSpaceStyle, overflowWrapStyle, Style]);
        
        builder.OpenElement(0, CarbonBlazorTextTypeMapper.ToHtmlTag(Type));
        builder.AddAttribute(1, "class", cssClass);
        builder.AddAttribute(2, "style", style);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}