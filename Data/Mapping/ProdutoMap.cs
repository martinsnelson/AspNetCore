using AspNetCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.ProdutoID);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Descricao).HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.DataValidade);
            builder.Property(x => x.DataFabricacao);
            builder.Property(x => x.Preco).IsRequired().HasColumnType("money");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos);
            builder.HasOne(x => x.Fornecedor).WithMany(x => x.Produtos);
        }
    }
}