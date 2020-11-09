using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Controllers.Services;

namespace WebApplication4.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IItemService, ItemService>();
            serviceCollection.AddSingleton<IOrcamentoService, OrcamentoService>();
            serviceCollection.AddSingleton<IItemOrcamentoService, ItemOrcamentoService>();
            return serviceCollection;
        }
    }
}
