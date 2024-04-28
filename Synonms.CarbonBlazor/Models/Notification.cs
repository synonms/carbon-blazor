using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class Notification : IDisposable, IAsyncDisposable
{
    private readonly Timer _timer;
    
    public Notification(string title, string message, int lifetimeInMs = 5000)
    {
        Title = title;
        Message = message;

        _timer = new Timer(_ => OnExpired.Invoke(this), null, TimeSpan.FromMilliseconds(lifetimeInMs), Timeout.InfiniteTimeSpan);
    }

    public Guid Id { get; } = Guid.NewGuid();
    
    public string Title { get; }

    public string Message { get; }
    
    public CarbonBlazorNotificationLevel Level { get; init; } = CarbonBlazorNotificationLevel.Information;

    public CarbonBlazorNotificationStyle Style { get; init; } = CarbonBlazorNotificationStyle.HighContrast;

    public Action<Notification> OnExpired { get; set; } = _ => {};

    public void Dispose()
    {
        _timer.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _timer.DisposeAsync();
    }
}
