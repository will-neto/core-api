using Loja.Domain.Categorias;
using Loja.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Loja.Api.Application.Commands
{
    public class CategoriaCommandHandler : 
        IRequestHandler<CategoriaCommand, CategoriaCommandResponse>,
        IRequestHandler<CategoriaEditarStatusCommand, CategoriaCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private CancellationToken _cancellationToken;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaCommandHandler(IUnitOfWork uow, ICategoriaRepository categoriaRepository)
        {
            _uow = uow;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaCommandResponse> Handle(CategoriaCommand request, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            try
            {
                var categoria = CategoriaFactory.Incluir(request.Descricao, request.ImagemUrl);

                await _categoriaRepository.AddAsync(categoria);

                _uow.Commit();
            }
            catch
            {
                return new CategoriaCommandResponse(false, "Ocorreu um erro intero!");
            }

            return new CategoriaCommandResponse(true, string.Empty);
        }

        public async Task<CategoriaCommandResponse> Handle(CategoriaEditarStatusCommand request, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            try
            {
                var categoria = await _categoriaRepository.ObterAsync(request.CategoriaId);

                if (categoria != null)
                {
                    categoria.Ativo = request.Ativo;

                    await _categoriaRepository.UpdateAsync(categoria);

                    _uow.Commit();
                }
            }
            catch
            {
                return new CategoriaCommandResponse(false, "Ocorreu um erro intero!");
            }

            return new CategoriaCommandResponse(true, string.Empty);
        }
    }
}
