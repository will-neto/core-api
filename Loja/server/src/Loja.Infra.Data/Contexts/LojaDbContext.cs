using Loja.Domain.Categorias;
using Loja.Domain.Produtos;
using Loja.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;


namespace Loja.Infra.Data.Contexts
{
    public class LojaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Loja;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            //modelBuilder.ApplyConfiguration(new PostConfiguration());
        }

        //public LojaDbContext(DbContextOptions<LojaDbContext> options) : base(options)
        //{

        //}

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }


    }
}
