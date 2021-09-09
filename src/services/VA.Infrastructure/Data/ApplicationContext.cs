using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetDevPack.Security.Jwt.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;
using System;
using VA.Domain;
using VA.Infrastructure.Data.Identity;
using VA.Infrastructure.Extensions;

namespace VA.Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser, IdentityRole, string>, ISecurityKeyContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<Habilidade> Habilidade { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Senioridade> Senioridade { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer("Server=localhost,1433;Database=vagas_aqui;User ID=sa;Password=1q2w3e4r@#$")
        //        .LogTo(Console.WriteLine, LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly)
                .ToVarchar()
                .ToDeleteRestrict()
                .ToSnakeCaseNames();
        }
    }
}
