using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Models;

namespace Synonms.CarbonBlazor.Infrastructure;

public class NotificationBroker : INotificationBroker
{
    private readonly List<Notification> _notifications = [];

    public event EventHandler? NotificationsUpdated;

    public IEnumerable<Notification> Notifications => _notifications;

    public void Send(string title, string message, CarbonBlazorNotificationLevel level = CarbonBlazorNotificationLevel.Information, int lifetimeInMs = 5000)
    {
        Notification notification = new(title, message, lifetimeInMs)
        {
            Level = level
        };

        Send(notification);
    }

    public void Send(Notification notification)
    {
        notification.OnExpired = Remove;
        
        _notifications.Add(notification);
        
        NotificationsUpdated?.Invoke(this, EventArgs.Empty);
    }
    
    private void Remove(Notification notification)
    {
        _notifications.Remove(notification);
        
        NotificationsUpdated?.Invoke(this, EventArgs.Empty);
    }
}