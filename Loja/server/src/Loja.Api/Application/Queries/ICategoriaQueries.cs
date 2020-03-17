using Loja.Domain.Categorias;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Api.Application.Queries
{
    public interface ICategoriaQueries
    {
        Task<List<Categoria>> ListarAsync();
    }
}
