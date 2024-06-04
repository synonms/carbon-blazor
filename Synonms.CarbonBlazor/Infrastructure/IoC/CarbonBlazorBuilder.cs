using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Synonms.CarbonBlazor.Infrastructure.MultiTenancy;

namespace Synonms.CarbonBlazor.Infrastructure.IoC;

public class CarbonBlazorBuilder
{
    private readonly IServiceCollection _serviceCollection;

    public CarbonBlazorBuilder(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public CarbonBlazorBuilder WithTenantProvider<TTenantProvider>() where TTenantProvider : class, ITenantProvider
    {
        _serviceCollection.Replace(ServiceDescriptor.Singleton<ITenantProvider, TTenantProvider>());

        return this;
    }
}