using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VA.Domain;

namespace VA.Infrastructure.Data
{
    public interface IApplicationContext
    {
        DbSet<Empresa> Empresa { get; set; }
        DbSet<Estado> Estado { get; set; }
        Task<int> SaveChangesAsync();
    }
}
