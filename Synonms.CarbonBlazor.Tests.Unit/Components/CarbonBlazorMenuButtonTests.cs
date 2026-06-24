using Bunit;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Components;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorMenuButtonTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose() => _ctx.Dispose();

    private static RenderFragment CreateItems() =>
        builder =>
        {
            builder.OpenComponent<CarbonBlazorMenuItem>(0);
            builder.AddAttribute(1, "Label", "Option 1");
            builder.CloseComponent();
        };

    [Fact]
    public void Renders_TriggerButton()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Items, CreateItems()));

        cut.Find(".cb-menu-button-trigger");
    }

    [Fact]
    public void Renders_LabelText()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("Actions", cut.Find(".cb-menu-button-trigger").TextContent);
    }

    [Fact]
    public void Renders_WithPrimaryClass_ByDefault()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("primary", cut.Find(".cb-menu-button-trigger").ClassList);
    }

    [Fact]
    public void Renders_WithKindClass()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Kind, CarbonBlazorButtonKind.Tertiary)
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("tertiary", cut.Find(".cb-menu-button-trigger").ClassList);
    }

    [Fact]
    public void Menu_IsCollapsed_Initially()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Menu_Opens_OnButtonClick()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Items, CreateItems()));

        cut.Find(".cb-menu-button-trigger").Click();

        Assert.DoesNotContain("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Menu_Closes_OnSecondButtonClick()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Items, CreateItems()));

        cut.Find(".cb-menu-button-trigger").Click();
        cut.Find(".cb-menu-button-trigger").Click();

        Assert.Contains("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Renders_Disabled_WhenIsDisabledTrue()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.IsDisabled, true)
                .Add(p => p.Items, CreateItems()));

        Assert.NotNull(cut.Find(".cb-menu-button-trigger").GetAttribute("disabled"));
    }

    [Fact]
    public void Renders_WithSizeClass()
    {
        IRenderedComponent<CarbonBlazorMenuButton> cut = _ctx.Render<CarbonBlazorMenuButton>(
            parameters => parameters
                .Add(p => p.Label, "Actions")
                .Add(p => p.Size, CarbonBlazorMenuItemSize.Large)
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("large", cut.Find(".cb-menu-button-trigger").ClassList);
    }
}
