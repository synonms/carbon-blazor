using Bunit;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Components;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorMenuTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose() => _ctx.Dispose();

    [Fact]
    public void Renders_MenuElement()
    {
        IRenderedComponent<CarbonBlazorMenu> cut = _ctx.Render<CarbonBlazorMenu>();

        cut.Find(".cb-menu");
    }

    [Fact]
    public void Renders_WithMenuRole()
    {
        IRenderedComponent<CarbonBlazorMenu> cut = _ctx.Render<CarbonBlazorMenu>();

        Assert.Equal("menu", cut.Find(".cb-menu").GetAttribute("role"));
    }

    [Fact]
    public void Renders_WithSizeClass()
    {
        IRenderedComponent<CarbonBlazorMenu> cut = _ctx.Render<CarbonBlazorMenu>(
            parameters => parameters.Add(p => p.Size, CarbonBlazorMenuItemSize.Large));

        Assert.Contains("large", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Renders_Visible_WhenIsOpenTrue()
    {
        IRenderedComponent<CarbonBlazorMenu> cut = _ctx.Render<CarbonBlazorMenu>(
            parameters => parameters.Add(p => p.IsOpen, true));

        Assert.DoesNotContain("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Renders_Collapsed_WhenIsOpenFalse()
    {
        IRenderedComponent<CarbonBlazorMenu> cut = _ctx.Render<CarbonBlazorMenu>(
            parameters => parameters.Add(p => p.IsOpen, false));

        Assert.Contains("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Renders_ChildContent()
    {
        IRenderedComponent<CarbonBlazorMenu> cut = _ctx.Render<CarbonBlazorMenu>(
            parameters => parameters.AddChildContent("<li class=\"test-item\">Item</li>"));

        cut.Find(".test-item");
    }
}
