using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.Cidade)
                .WithMany(p => p.Empresas)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
