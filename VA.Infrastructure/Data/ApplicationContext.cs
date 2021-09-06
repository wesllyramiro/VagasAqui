using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using VA.Domain;
using VA.Infrastructure.Extensions;

namespace VA.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Estado> Estado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Server=localhost,1433;Database=vagas_aqui;User ID=sa;Password=1q2w3e4r@#$";

            optionsBuilder
                .UseSqlServer(strConnection, o => o.EnableRetryOnFailure())
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
