using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication4
{
    public interface IInstaller
    {
        void IntallServices(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
