using AspNetCore.Entities;
using AspNetCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data
{
    public class AspNetCoreContext : DbContext
    {
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public AspNetCoreContext(DbContextOptions<AspNetCoreContext> options) : base(options)
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