using AspNetCoreAngular.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreAngular.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.UsuarioID);
            builder.Property(x => x.Nome).HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Email).HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(x => x.Senha).HasMaxLength(128).HasColumnType("varbinary(128)");
            builder.Property(x => x.Salt).HasMaxLength(128).HasColumnType("varbinary(128)");
        }
    }
}