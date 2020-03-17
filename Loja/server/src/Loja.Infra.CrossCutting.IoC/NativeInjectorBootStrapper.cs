using Loja.Domain.Categorias;
using Loja.Infra.Data.Contexts;
using Loja.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<LojaDbContext>();
        }
    }
}
