using Microsoft.Extensions.DependencyInjection;

namespace Synonms.CarbonBlazor.Infrastructure.IoC;

public class CarbonBlazorBuilder
{
    private readonly IServiceCollection _serviceCollection;

    public CarbonBlazorBuilder(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }
}