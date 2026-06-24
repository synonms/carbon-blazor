using Bunit;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Components;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorOverflowMenuButtonTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose() => _ctx.Dispose();

    private static RenderFragment CreateItems() =>
        builder =>
        {
            builder.OpenComponent<CarbonBlazorMenuItem>(0);
            builder.AddAttribute(1, "Label", "Edit");
            builder.CloseComponent();
        };

    [Fact]
    public void Renders_TriggerButton()
    {
        IRenderedComponent<CarbonBlazorOverflowMenuButton> cut = _ctx.Render<CarbonBlazorOverflowMenuButton>(
            parameters => parameters.Add(p => p.Items, CreateItems()));

        cut.Find(".cb-overflow-menu-button-trigger");
    }

    [Fact]
    public void Menu_IsCollapsed_Initially()
    {
        IRenderedComponent<CarbonBlazorOverflowMenuButton> cut = _ctx.Render<CarbonBlazorOverflowMenuButton>(
            parameters => parameters.Add(p => p.Items, CreateItems()));

        Assert.Contains("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Menu_Opens_OnTriggerButtonClick()
    {
        IRenderedComponent<CarbonBlazorOverflowMenuButton> cut = _ctx.Render<CarbonBlazorOverflowMenuButton>(
            parameters => parameters.Add(p => p.Items, CreateItems()));

        cut.Find(".cb-overflow-menu-button-trigger").Click();

        Assert.DoesNotContain("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Menu_Closes_OnSecondTriggerButtonClick()
    {
        IRenderedComponent<CarbonBlazorOverflowMenuButton> cut = _ctx.Render<CarbonBlazorOverflowMenuButton>(
            parameters => parameters.Add(p => p.Items, CreateItems()));

        cut.Find(".cb-overflow-menu-button-trigger").Click();
        cut.Find(".cb-overflow-menu-button-trigger").Click();

        Assert.Contains("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Renders_Disabled_WhenIsDisabledTrue()
    {
        IRenderedComponent<CarbonBlazorOverflowMenuButton> cut = _ctx.Render<CarbonBlazorOverflowMenuButton>(
            parameters => parameters
                .Add(p => p.IsDisabled, true)
                .Add(p => p.Items, CreateItems()));

        Assert.NotNull(cut.Find(".cb-overflow-menu-button-trigger").GetAttribute("disabled"));
    }

    [Fact]
    public void Renders_WithSizeClass()
    {
        IRenderedComponent<CarbonBlazorOverflowMenuButton> cut = _ctx.Render<CarbonBlazorOverflowMenuButton>(
            parameters => parameters
                .Add(p => p.Size, CarbonBlazorMenuItemSize.Small)
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("small", cut.Find(".cb-overflow-menu-button-wrapper").ClassList);
    }
}
