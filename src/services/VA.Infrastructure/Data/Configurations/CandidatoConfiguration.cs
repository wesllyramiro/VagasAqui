using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder
                .HasOne(p => p.Perfil)
                .WithMany(p => p.Candidaturas)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Vaga)
                .WithMany(p => p.Candidatos)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
