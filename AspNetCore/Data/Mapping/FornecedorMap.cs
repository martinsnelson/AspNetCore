using AspNetCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Mapping
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");
            builder.HasKey(x => x.FornecedorID);
            builder.Property(x => x.Nome).HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Telefone).HasMaxLength(14).HasColumnType("varchar(14)");
            builder.Property(x => x.CNPJ).HasMaxLength(14).HasColumnType("bigint");
        }
    }
}