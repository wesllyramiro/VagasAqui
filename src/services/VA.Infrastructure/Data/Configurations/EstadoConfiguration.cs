using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(o => o.Cidades)
                .WithOne(c => c.Estado);
        }
    }
}
