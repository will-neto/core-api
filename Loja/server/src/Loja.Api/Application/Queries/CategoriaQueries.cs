using Loja.Domain.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Api.Application.Queries
{
    public class CategoriaQueries : ICategoriaQueries
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaQueries(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Categoria>> ListarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
