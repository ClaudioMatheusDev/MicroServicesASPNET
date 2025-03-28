using Microsoft.EntityFrameworkCore;
using Produtos.api.Models;

namespace Produtos.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { } // Construtor que recebe um objeto do tipo DbContextOptions<AppDbContext>
                                                                                       //  e passa para a classe base (DbContext) através do construtor base(options)

        public DbSet<Produto> Produtos { get; set; } // Propriedade do tipo DbSet<Produto> que representa a tabela Produtos no banco de dados
    }
}
