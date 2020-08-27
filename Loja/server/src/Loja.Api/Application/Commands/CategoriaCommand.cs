using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Api.Application.Commands
{
    public class CategoriaCommand : IRequest<CategoriaCommandResponse>
    {
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public bool Ativo { get; set; }
    }

    public class CategoriaEditarStatusCommand : IRequest<CategoriaCommandResponse>
    {
        public int CategoriaId { get; set; }
        public bool Ativo { get; set; }
    }
    public class CategoriaCommandResponse
    {
        public bool Valido { get; private set; }
        public string Notificacao { get; private set; }

        public CategoriaCommandResponse(bool valido, string notificacao)
        {
            this.Valido = valido;
            this.Notificacao = notificacao;
        }
    }
}
