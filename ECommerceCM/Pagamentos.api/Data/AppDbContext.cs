using Microsoft.EntityFrameworkCore;
using Pagamentos.api.Models;

namespace Pagamentos.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Pago> Pagamentos { get; set; }
    }
}
