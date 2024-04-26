using Microsoft.Extensions.DependencyInjection;

namespace Synonms.CarbonBlazor.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCarbonBlazor(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<INotificationBroker, NotificationBroker>();

        return serviceCollection;
    }
}