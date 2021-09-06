using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class ExperienciaConfiguration : IEntityTypeConfiguration<Experiencia>
    {
        public void Configure(EntityTypeBuilder<Experiencia> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .HasOne(p => p.Perfil)
                .WithMany(p => p.Experiencias);
        }
    }
}
