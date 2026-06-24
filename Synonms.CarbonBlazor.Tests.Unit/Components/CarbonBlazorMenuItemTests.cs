using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorMenuItemTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose() => _ctx.Dispose();

    [Fact]
    public void Renders_WithLabel()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters.Add(p => p.Label, "Test Item"));

        Assert.Contains("Test Item", cut.Find(".cb-menu-item-label").TextContent);
    }

    [Fact]
    public void Renders_WithMenuItemRole()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters.Add(p => p.Label, "Test Item"));

        Assert.Equal("menuitem", cut.Find(".cb-menu-item").GetAttribute("role"));
    }

    [Fact]
    public void Renders_WithMenuItemCheckboxRole_WhenSelected()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Test Item")
                .Add(p => p.IsSelected, true));

        Assert.Equal("menuitemcheckbox", cut.Find(".cb-menu-item").GetAttribute("role"));
    }

    [Fact]
    public void Renders_WithDisabledClass_WhenDisabled()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Test Item")
                .Add(p => p.IsDisabled, true));

        Assert.Contains("disabled", cut.Find(".cb-menu-item").ClassList);
    }

    [Fact]
    public void Renders_WithDangerClass_WhenDanger()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Test Item")
                .Add(p => p.IsDanger, true));

        Assert.Contains("danger", cut.Find(".cb-menu-item").ClassList);
    }

    [Fact]
    public void Renders_WithSelectedClass_WhenSelected()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Test Item")
                .Add(p => p.IsSelected, true));

        Assert.Contains("selected", cut.Find(".cb-menu-item").ClassList);
    }

    [Fact]
    public void Renders_KeyboardShortcut_WhenProvided()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Copy")
                .Add(p => p.KeyboardShortcut, "⌘C"));

        Assert.Contains("⌘C", cut.Find(".cb-menu-item-shortcut").TextContent);
    }

    [Fact]
    public void DoesNotRender_KeyboardShortcut_WhenNotProvided()
    {
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters.Add(p => p.Label, "Item"));

        Assert.Empty(cut.FindAll(".cb-menu-item-shortcut"));
    }

    [Fact]
    public async Task InvokesClickedCallback_OnClick()
    {
        bool wasClicked = false;
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Click Me")
                .Add(p => p.ClickedCallback, EventCallback.Factory.Create(this, () => { wasClicked = true; })));

        await cut.Find(".cb-menu-item").ClickAsync(new MouseEventArgs());

        Assert.True(wasClicked);
    }

    [Fact]
    public async Task DoesNotInvokeClickedCallback_WhenDisabled()
    {
        bool wasClicked = false;
        IRenderedComponent<CarbonBlazorMenuItem> cut = _ctx.Render<CarbonBlazorMenuItem>(
            parameters => parameters
                .Add(p => p.Label, "Disabled Item")
                .Add(p => p.IsDisabled, true)
                .Add(p => p.ClickedCallback, EventCallback.Factory.Create(this, () => { wasClicked = true; })));

        await cut.Find(".cb-menu-item").ClickAsync(new MouseEventArgs());

        Assert.False(wasClicked);
    }
}
