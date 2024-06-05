using Microsoft.Extensions.DependencyInjection;

namespace Synonms.CarbonBlazor.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static CarbonBlazorBuilder AddCarbonBlazor(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<INotificationBroker, NotificationBroker>();

        return new CarbonBlazorBuilder(serviceCollection);
    }
}