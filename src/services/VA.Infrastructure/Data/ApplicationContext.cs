using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.Data.Identity;
using VA.Infrastructure.Extensions;

namespace VA.Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser, IdentityRole, string>, ISecurityKeyContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

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

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
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
