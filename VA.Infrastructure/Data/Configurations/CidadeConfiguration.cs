using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
