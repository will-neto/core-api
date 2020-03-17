using Loja.Domain.Categorias;
using Loja.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly LojaDbContext _lojaDbContext;
        public CategoriaRepository(LojaDbContext lojaDbContext)
        {
            _lojaDbContext = lojaDbContext;
        }

        public async Task<IEnumerable<Categoria>> ListarAsync()
        {
            return await _lojaDbContext.Categorias.ToListAsync();
        }
    }
}
