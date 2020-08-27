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


        public async Task AddAsync(Categoria entity)
        {
            await _lojaDbContext.AddAsync(entity);

            //await _lojaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> ListarAsync()
        {
            return await _lojaDbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> ObterAsync(int categoriaId)
        {
            return await _lojaDbContext.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == categoriaId);
        }

        public async Task UpdateAsync(Categoria entity)
        {
            await Task.FromResult(_lojaDbContext.Categorias.Update(entity));
        }
    }
}
