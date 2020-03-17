using Loja.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
