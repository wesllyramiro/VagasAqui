using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VA.Domain;
using VA.Infrastructure.Extensions;

namespace VA.Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationContext(DbContextOptions options) : base(options){ }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(p => p.GetProperties())
                .Where(p => p.ClrType == typeof(string)
                        && p.GetColumnType() == null);

            foreach (var property in properties)
            {
                property.SetIsUnicode(false);
            }

            modelBuilder.ToSnakeCaseNames();
        }
    }
}
