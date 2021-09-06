using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder
                .Property(p => p.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(p => p.Empresa)
                .WithMany(p => p.Vagas);

            builder
                .HasOne(p => p.Senioridade)
                .WithOne(p => p.Vaga);
        }
    }
}
