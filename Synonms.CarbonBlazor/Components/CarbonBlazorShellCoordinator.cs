using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace Synonms.CarbonBlazor.Components;

internal sealed class CarbonBlazorShellCoordinator
{
    public event Func<string?, Task>? RightPanelChanged;

    public event Action? NavigationChanged;

    public event Action? ThemeUpdated;

    public CarbonBlazorTheme Theme { get; set; } = CarbonBlazorTheme.White;

    public EventCallback<CarbonBlazorTheme> ThemeChanged { get; set; }

    public bool HasLeftPanel { get; set; }

    public bool IsNavigationExpanded { get; set; } = true;

    public bool IsMobileNavigationOpen { get; set; }

    public string NavigationId { get; set; } = string.Empty;

    public IReadOnlyList<NavigationItem> HeaderNavigation { get; set; } = [];

    public Func<Task>? ToggleNavigation { get; set; }

    public Func<Task>? ToggleMobileNavigation { get; set; }

    public Func<Task>? CloseMobileNavigation { get; set; }

    public Func<Task>? RestoreNavigationFocus { get; set; }

    public void NotifyNavigationChanged() => NavigationChanged?.Invoke();

    public void NotifyThemeUpdated() => ThemeUpdated?.Invoke();

    public async Task ToggleRightPanel(string panelId)
    {
        _openPanelId = panelId == _openPanelId ? null : panelId;
        await NotifyRightPanelChanged(_openPanelId);
    }

    public async Task CloseRightPanels()
    {
        if (_openPanelId is null)
        {
            return;
        }

        _openPanelId = null;
        await NotifyRightPanelChanged(null);
    }

    public bool IsRightPanelOpen(string panelId) => _openPanelId == panelId;

    private async Task NotifyRightPanelChanged(string? panelId)
    {
        Delegate[] handlers = RightPanelChanged?.GetInvocationList() ?? [];
        foreach (Delegate handler in handlers)
        {
            await ((Func<string?, Task>)handler).Invoke(panelId);
        }
    }

    private string? _openPanelId;
}
