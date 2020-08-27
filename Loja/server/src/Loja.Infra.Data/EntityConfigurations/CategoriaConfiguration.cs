using Loja.Domain.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Infra.Data.EntityConfigurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.HasKey(e => e.CategoriaId);

            builder.Property(e => e.Descricao).HasMaxLength(60);

            builder.Property(e => e.ImagemUrl).HasMaxLength(60);

            builder.Property(e => e.Ativo);

            builder.Ignore(e => e.Id);
        }
    }
}
