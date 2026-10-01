using Bunit;
using Microsoft.AspNetCore.Components;
using Synonms.CarbonBlazor.Components;
using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Models;
using Synonms.CarbonBlazor.Infrastructure.IoC;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorShellTests : IDisposable
{
    private readonly BunitContext _ctx = new();

    public CarbonBlazorShellTests()
    {
        _ctx.Services.AddCarbonBlazor();
    }

    public void Dispose() => _ctx.Dispose();

    [Fact]
    public void HeaderOnlyShellHasSkipLinkAndNoMenu()
    {
        IRenderedComponent<CarbonBlazorShell> cut = _ctx.Render<CarbonBlazorShell>(parameters => parameters
            .Add(p => p.HeaderContent, builder =>
            {
                builder.OpenComponent<CarbonBlazorShellHeader>(0);
                builder.AddAttribute(1, nameof(CarbonBlazorShellHeader.ProductName), "Product");
                builder.CloseComponent();
            })
            .Add(p => p.ChildContent, "Page content"));

        Assert.Equal($"#{cut.Find("main").Id}", cut.Find(".cb-shell-skip-link").GetAttribute("href"));
        Assert.Empty(cut.FindAll(".cb-shell-menu-button"));
        Assert.Empty(cut.FindAll(".cb-shell-right-panel"));
        Assert.Equal("Product", cut.Find(".cb-shell-product").TextContent);
    }

    [Fact]
    public void OptionalRightPanelsOpenExclusively()
    {
        IRenderedComponent<CarbonBlazorShell> cut = RenderWithPanels();

        cut.Find("button[aria-label='Account']").Click();
        Assert.Equal("false", cut.Find("button[aria-label='Application switcher']").GetAttribute("aria-expanded"));
        Assert.Equal("true", cut.Find("button[aria-label='Account']").GetAttribute("aria-expanded"));

        cut.Find("button[aria-label='Application switcher']").Click();
        Assert.Equal("false", cut.Find("button[aria-label='Account']").GetAttribute("aria-expanded"));
        Assert.Equal("true", cut.Find("button[aria-label='Application switcher']").GetAttribute("aria-expanded"));
        Assert.Single(cut.FindAll(".cb-shell-right-panel:not([hidden])"));
    }

    [Fact]
    public void SelectingRightPanelLinkDismissesPanel()
    {
        IRenderedComponent<CarbonBlazorShell> cut = RenderWithPanels();
        cut.Find("button[aria-label='Account']").Click();
        cut.Find(".cb-header-action-link a").Click();

        Assert.Equal("false", cut.Find("button[aria-label='Account']").GetAttribute("aria-expanded"));
    }

    [Fact]
    public void EscapeAndOutsideClickDismissRightPanel()
    {
        IRenderedComponent<CarbonBlazorShell> cut = RenderWithPanels();
        cut.Find("button[aria-label='Account']").Click();
        cut.Find(".cb-shell-layout").KeyDown("Escape");
        Assert.Equal("false", cut.Find("button[aria-label='Account']").GetAttribute("aria-expanded"));

        cut.Find("button[aria-label='Account']").Click();
        cut.Find(".cb-shell-panel-backdrop").Click();
        Assert.Equal("false", cut.Find("button[aria-label='Account']").GetAttribute("aria-expanded"));
    }

    [Fact]
    public void HeaderNavigationAppearsBeforeSecondaryNavigationOnMobile()
    {
        IRenderedComponent<CarbonBlazorShell> cut = _ctx.Render<CarbonBlazorShell>(parameters => parameters
            .Add(p => p.HeaderContent, builder =>
            {
                builder.OpenComponent<CarbonBlazorShellHeader>(0);
                builder.AddAttribute(1, nameof(CarbonBlazorShellHeader.ProductName), "Product");
                builder.AddAttribute(2, nameof(CarbonBlazorShellHeader.HeaderNavigation),
                    new[] { NavigationItem.Create("Products", "/products") });
                builder.CloseComponent();
            })
            .Add(p => p.LeftPanelContent, builder =>
            {
                builder.OpenComponent<CarbonBlazorShellLeftPanel>(0);
                builder.AddAttribute(1, nameof(CarbonBlazorShellLeftPanel.ChildContent), (RenderFragment)(items =>
                {
                    items.OpenComponent<CarbonBlazorSidebarLink>(0);
                    items.AddAttribute(1, nameof(CarbonBlazorSidebarLink.NavigationItem),
                        NavigationItem.Create("Users", "/users"));
                    items.CloseComponent();
                }));
                builder.CloseComponent();
            })
            .Add(p => p.ChildContent, "Page"));

        Assert.Equal("false", cut.Find(".mobile-menu-button").GetAttribute("aria-expanded"));
        cut.Find(".mobile-menu-button").Click();
        Assert.Equal("true", cut.Find(".mobile-menu-button").GetAttribute("aria-expanded"));
        Assert.Contains("mobile-open", cut.Find(".cb-shell-left-panel").ClassList);
        Assert.Equal("Products", cut.Find(".cb-shell-mobile-product-navigation a").TextContent);
        Assert.Equal("Users", cut.Find(".cb-shell-secondary-navigation a").TextContent);
        cut.Find(".cb-shell-secondary-navigation a").Click();
        Assert.Equal("false", cut.Find(".mobile-menu-button").GetAttribute("aria-expanded"));
    }

    [Fact]
    public void ThemeSelectionEmitsSelectedValue()
    {
        CarbonBlazorTheme? selectedTheme = null;
        IRenderedComponent<CarbonBlazorShell> cut = _ctx.Render<CarbonBlazorShell>(parameters => parameters
            .Add(p => p.ThemeChanged, theme => selectedTheme = theme)
            .Add(p => p.HeaderContent, builder =>
            {
                builder.OpenComponent<CarbonBlazorShellHeader>(0);
                builder.AddAttribute(1, nameof(CarbonBlazorShellHeader.ProductName), "Product");
                builder.AddAttribute(2, nameof(CarbonBlazorShellHeader.EnableThemeSwitcher), true);
                builder.CloseComponent();
            })
            .Add(p => p.ChildContent, "Page"));

        cut.Find("button[aria-label='Choose theme']").Click();
        cut.FindAll(".cb-shell-theme-options button").Single(button => button.TextContent == "Gray 90").Click();

        Assert.Equal(CarbonBlazorTheme.Gray90, selectedTheme);
        Assert.Equal("false", cut.Find("button[aria-label='Choose theme']").GetAttribute("aria-expanded"));
    }

    [Fact]
    public void LeftPanelIsOptionalAndSubmenusAreAccessible()
    {
        IRenderedComponent<CarbonBlazorShellLeftPanel> cut = _ctx.Render<CarbonBlazorShellLeftPanel>(parameters => parameters
            .Add(p => p.ChildContent, builder =>
            {
                builder.OpenComponent<CarbonBlazorSidebarSubMenu>(0);
                builder.AddAttribute(1, nameof(CarbonBlazorSidebarSubMenu.Text), "Resources");
                builder.AddAttribute(2, nameof(CarbonBlazorSidebarSubMenu.SubMenuItems),
                    new[] { NavigationItem.Create("Users", "/users") });
                builder.CloseComponent();
            }));

        Assert.Equal("false", cut.Find(".cb-sidebar-submenu-toggle").GetAttribute("aria-expanded"));
        Assert.True(cut.Find(".cb-sidebar-submenu-items").HasAttribute("hidden"));
        cut.Find(".cb-sidebar-submenu-toggle").Click();
        Assert.Equal("true", cut.Find(".cb-sidebar-submenu-toggle").GetAttribute("aria-expanded"));
        Assert.False(cut.Find(".cb-sidebar-submenu-items").HasAttribute("hidden"));
    }

    private IRenderedComponent<CarbonBlazorShell> RenderWithPanels() =>
        _ctx.Render<CarbonBlazorShell>(parameters => parameters
            .Add(p => p.HeaderContent, builder =>
            {
                builder.OpenComponent<CarbonBlazorShellHeader>(0);
                builder.AddAttribute(1, nameof(CarbonBlazorShellHeader.ProductName), "Product");
                builder.AddAttribute(2, nameof(CarbonBlazorShellHeader.AccountPanel), (RenderFragment)(content =>
                {
                    content.OpenComponent<CarbonBlazorHeaderActionLink>(0);
                    content.AddAttribute(1, nameof(CarbonBlazorHeaderActionLink.NavigationItem),
                        NavigationItem.Create("Account settings", "/settings"));
                    content.CloseComponent();
                }));
                builder.AddAttribute(3, nameof(CarbonBlazorShellHeader.SwitcherPanel), (RenderFragment)(content =>
                {
                    content.AddContent(0, "Other product");
                }));
                builder.CloseComponent();
            })
            .Add(p => p.ChildContent, "Page"));
}
