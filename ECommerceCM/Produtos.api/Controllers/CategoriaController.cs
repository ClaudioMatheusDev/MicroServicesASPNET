using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produtos.api.Data;
using Produtos.api.Models;

namespace Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet] // Define a rota para a ação GetCategorias
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias() // Define a ação GetCategorias
        {
            return await _context.Categorias.ToListAsync(); // Retorna a lista de categorias 
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id) // Define a ação GetCategoria passando o id como parâmetro 
        {
            var categoria = await _context.Categorias.FindAsync(id); // Busca a categoria pelo id 

            if (categoria == null) // Se a categoria não for encontrada
            {
                return NotFound(); // Retorna 404 Not Found
            }

            return categoria;
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria) // Define a ação PostCategoria passando um objeto do tipo Categoria como parâmetro
        {
            _context.Categorias.Add(categoria); //_CONTEXT passando categoria como parâmetro e .add para adicionar a categoria
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria); // Retorna 201 Created e a URI do novo recurso
        }
    }
}
