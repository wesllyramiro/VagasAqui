using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class PaginaConfiguration : IEntityTypeConfiguration<Pagina>
    {
        public void Configure(EntityTypeBuilder<Pagina> builder)
        {
            builder
                .HasOne(p => p.Empresa)
                .WithOne(p => p.Pagina)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Perfil)
                .WithMany(p => p.Paginas)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
