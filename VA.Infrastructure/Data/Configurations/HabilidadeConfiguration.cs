using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class HabilidadeConfiguration : IEntityTypeConfiguration<Habilidade>
    {
        public void Configure(EntityTypeBuilder<Habilidade> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.Perfil)
                .WithMany(p => p.Habilidades);
        }
    }
}
