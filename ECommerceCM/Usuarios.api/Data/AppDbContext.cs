using Microsoft.EntityFrameworkCore;
using Usuarios.api.Models;


namespace Usuarios.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}