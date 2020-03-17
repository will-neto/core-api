using Loja.Domain.Produtos;
using Loja.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Categorias
{
    public class Categoria : Entity, IAggregateRoot
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public int CategoriaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
