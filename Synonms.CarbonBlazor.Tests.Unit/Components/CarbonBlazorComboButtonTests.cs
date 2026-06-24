using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Synonms.CarbonBlazor.Components;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorComboButtonTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose() => _ctx.Dispose();

    private static RenderFragment CreateItems() =>
        builder =>
        {
            builder.OpenComponent<CarbonBlazorMenuItem>(0);
            builder.AddAttribute(1, "Label", "Save as draft");
            builder.CloseComponent();
        };

    [Fact]
    public void Renders_PrimaryButton()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.Items, CreateItems()));

        cut.Find(".cb-combo-button-primary");
    }

    [Fact]
    public void Renders_TriggerButton()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.Items, CreateItems()));

        cut.Find(".cb-combo-button-trigger");
    }

    [Fact]
    public void Renders_LabelText_OnPrimaryButton()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("Save", cut.Find(".cb-combo-button-primary").TextContent);
    }

    [Fact]
    public void Menu_IsCollapsed_Initially()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public void Menu_Opens_OnTriggerButtonClick()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.Items, CreateItems()));

        cut.Find(".cb-combo-button-trigger").Click();

        Assert.DoesNotContain("collapsed", cut.Find(".cb-menu").ClassList);
    }

    [Fact]
    public async Task InvokesPrimaryActionCallback_OnPrimaryButtonClick()
    {
        bool wasInvoked = false;
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.PrimaryActionCallback, EventCallback.Factory.Create(this, () => { wasInvoked = true; }))
                .Add(p => p.Items, CreateItems()));

        await cut.Find(".cb-combo-button-primary").ClickAsync(new MouseEventArgs());

        Assert.True(wasInvoked);
    }

    [Fact]
    public void Renders_BothButtonsDisabled_WhenIsDisabledTrue()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.IsDisabled, true)
                .Add(p => p.Items, CreateItems()));

        Assert.NotNull(cut.Find(".cb-combo-button-primary").GetAttribute("disabled"));
        Assert.NotNull(cut.Find(".cb-combo-button-trigger").GetAttribute("disabled"));
    }

    [Fact]
    public void Renders_WithSizeClass()
    {
        IRenderedComponent<CarbonBlazorComboButton> cut = _ctx.Render<CarbonBlazorComboButton>(
            parameters => parameters
                .Add(p => p.Label, "Save")
                .Add(p => p.Size, CarbonBlazorMenuItemSize.Large)
                .Add(p => p.Items, CreateItems()));

        Assert.Contains("large", cut.Find(".cb-combo-button-wrapper").ClassList);
    }
}
