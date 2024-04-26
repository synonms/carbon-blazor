using Synonms.CarbonBlazor.Enumerations;
using Synonms.CarbonBlazor.Models;

namespace Synonms.CarbonBlazor.Infrastructure;

public interface INotificationBroker
{
    event EventHandler? NotificationsUpdated;
        
    IEnumerable<Notification> Notifications { get; }

    void Send(string title, string message, CarbonBlazorNotificationLevel level = CarbonBlazorNotificationLevel.Information, int lifetimeInMs = 5000);

    void Send(Notification notification);
}