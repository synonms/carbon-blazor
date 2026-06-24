using Bunit;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorMenuItemDividerTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose() => _ctx.Dispose();

    [Fact]
    public void Renders_DividerElement()
    {
        IRenderedComponent<CarbonBlazorMenuItemDivider> cut = _ctx.Render<CarbonBlazorMenuItemDivider>();

        cut.Find(".cb-menu-item-divider");
    }

    [Fact]
    public void Renders_WithSeparatorRole()
    {
        IRenderedComponent<CarbonBlazorMenuItemDivider> cut = _ctx.Render<CarbonBlazorMenuItemDivider>();

        Assert.Equal("separator", cut.Find(".cb-menu-item-divider").GetAttribute("role"));
    }
}
