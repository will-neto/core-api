using Loja.Domain.Categorias;
using Loja.Domain.Interfaces;
using Loja.Infra.CrossCutting.Identity.Models;
using Loja.Infra.Data.Contexts;
using Loja.Infra.Data.Repositories;
using Loja.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<LojaDbContext>();
        }
    }
}
