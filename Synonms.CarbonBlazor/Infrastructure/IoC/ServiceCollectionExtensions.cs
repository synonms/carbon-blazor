using Microsoft.Extensions.DependencyInjection;
using Synonms.CarbonBlazor.Infrastructure.MultiTenancy;

namespace Synonms.CarbonBlazor.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static CarbonBlazorBuilder AddCarbonBlazor(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<INotificationBroker, NotificationBroker>();
        serviceCollection.AddSingleton<ITenantProvider, NoOpTenantProvider>();
        serviceCollection.AddSingleton<TenantSelector>();

        return new CarbonBlazorBuilder(serviceCollection);
    }
}