using AspNetCoreAngular.Entities;
using AspNetCoreAngular.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngular.Data
{
    public class AspNetCoreAngularContext : DbContext
    {
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public AspNetCoreAngularContext(DbContextOptions<AspNetCoreAngularContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new CategoriaMap());
            builder.ApplyConfiguration(new FornecedorMap());
            builder.ApplyConfiguration(new UsuarioMap());
        }
    }
}