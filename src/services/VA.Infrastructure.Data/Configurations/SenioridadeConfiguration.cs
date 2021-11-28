using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class SenioridadeConfiguration : IEntityTypeConfiguration<Senioridade>
    {
        public void Configure(EntityTypeBuilder<Senioridade> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
