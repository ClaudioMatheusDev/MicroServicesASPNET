using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Usuarios.api.Data;
using Usuarios.api.Models;

namespace Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        /// <summary>
        /// Variável de contexto do banco de dados
        /// </summary>
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context) // Alteração do nome da variável e do tipo de retorno do método de void para UsuariosController 
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios() // Alteração do tipo de retorno do método de void para ActionResult<IEnumerable<Usuario>>
        {
            return await _context.Usuarios.ToListAsync(); // Alteração do nome da variável
        }

        // GET: api/Usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id) // Alteração do tipo de retorno do método de void para ActionResult<Usuario>
        {
            var usuario = await _context.Usuarios.FindAsync(id);  // Alteração do nome da variável

            if (usuario == null)
            {
                return NotFound(); // Alteração do nome da variável
            }

            return usuario; // Alteração do nome da variável
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario) //Alteração do tipo de retorno do método de void para ActionResult<Usuario>
        {
            _context.Usuarios.Add(usuario); // Alteração do nome da variável
            await _context.SaveChangesAsync(); // Alteração do nome da variável

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario); // Alteração do nome da variável
        }
    }
}
