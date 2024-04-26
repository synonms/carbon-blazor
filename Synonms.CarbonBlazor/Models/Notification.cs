using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Models;

public class Notification
{
    private Timer _timer;
    
    public Notification(string title, string message, int lifetimeInMs = 5000)
    {
        Title = title;
        Message = message;

        _timer = new Timer(_ => OnExpired.Invoke(this), null, TimeSpan.FromMilliseconds(lifetimeInMs), TimeSpan.FromMilliseconds(1000));
    }

    public Guid Id { get; } = Guid.NewGuid();
    
    public string Title { get; }

    public string Message { get; }
    
    public CarbonBlazorNotificationLevel Level { get; init; } = CarbonBlazorNotificationLevel.Information;

    public CarbonBlazorNotificationStyle Style { get; init; } = CarbonBlazorNotificationStyle.HighContrast;

    public Action<Notification> OnExpired { get; set; } = _ => {};
}
