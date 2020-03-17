using Loja.Domain.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Api.Application.Queries
{
    public class ProdutoQueries : IProdutoQueries
    {
        private readonly IProdutoRepository
        public Task<List<Produto>> ListarPorCategoriaAsync()
        {
            throw new NotImplementedException();
        }
    }
}
