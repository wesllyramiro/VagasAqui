using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Senha)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
