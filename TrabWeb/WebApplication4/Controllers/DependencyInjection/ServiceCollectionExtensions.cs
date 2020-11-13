using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Controllers.Services;

namespace WebApplication4.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IItemService, ItemService>();
            serviceCollection.AddScoped<IOrcamentoService, OrcamentoService>();
            serviceCollection.AddScoped<IItemOrcamentoService, ItemOrcamentoService>();
            return serviceCollection;
        }
    }
}
