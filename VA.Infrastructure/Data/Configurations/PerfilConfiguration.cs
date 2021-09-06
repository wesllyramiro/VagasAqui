using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Curriculo)
                .HasMaxLength(100);

            builder
                .Property(p => p.DDD)
                .HasMaxLength(3)
                .IsRequired();

            builder
                .Property(p => p.Telefone)
                .HasMaxLength(11)
                .IsRequired();

            builder
                .HasOne(p => p.Cidade)
                .WithMany(p => p.Perfils)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Usuario)
                .WithOne(p => p.Perfil)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
