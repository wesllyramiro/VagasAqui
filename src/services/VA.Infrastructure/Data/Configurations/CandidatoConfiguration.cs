using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder
                .HasOne(p => p.Perfil)
                .WithMany(p => p.Candidaturas);

            builder
                .HasOne(p => p.Vaga)
                .WithMany(p => p.Candidatos);
        }
    }
}
