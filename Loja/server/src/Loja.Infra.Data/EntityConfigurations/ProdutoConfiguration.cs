using Loja.Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infra.Data.EntityConfigurations
{
    public class ProdutoConfiguration :  IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.ProdutoId);
            builder.Property(e => e.Nome).HasMaxLength(60).IsRequired();
            builder.Property(e => e.Descricao).HasMaxLength(2000);

            builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos).HasForeignKey(e => e.CategoriaId);

            builder.Ignore(e => e.Id);
        }
    }
}
