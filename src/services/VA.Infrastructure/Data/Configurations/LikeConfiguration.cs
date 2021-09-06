using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VA.Domain;

namespace VA.Infrastructure.Data.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder
                .HasOne(p => p.Perfil)
                .WithMany(p => p.Likes)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Vaga)
                .WithMany(p => p.Likes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
