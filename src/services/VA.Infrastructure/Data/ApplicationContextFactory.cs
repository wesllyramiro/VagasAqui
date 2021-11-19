using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VA.Infrastructure.Data
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=vagas_aqui;User ID=sa;Password=1q2w3e4r@#$");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
