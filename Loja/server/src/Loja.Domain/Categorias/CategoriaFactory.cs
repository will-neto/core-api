using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Categorias
{
    public class CategoriaFactory
    {
        public static Categoria Incluir(string descricao, string imagemUrl)
        {
            return new Categoria(descricao, imagemUrl);
        }
    }
}
