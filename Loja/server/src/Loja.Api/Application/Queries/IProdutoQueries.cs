using Loja.Domain.Produtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Api.Application.Queries
{
    public interface IProdutoQueries
    {
        Task<List<Produto>> ListarPorCategoriaAsync();
    }
}
