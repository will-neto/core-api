using Loja.Domain.Categorias;
using Loja.Domain.Shared;

namespace Loja.Domain.Produtos
{
    public class Produto : Entity, IAggregateRoot
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
