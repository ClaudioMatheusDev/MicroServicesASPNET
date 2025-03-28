using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagamentos.api.Models;
using Pagamentos.api.Data;


namespace Pagamentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase // ControllerBase é uma classe do ASP.NET Core que fornece funcionalidades comuns para os controladores da Web API
    {
        private readonly AppDbContext _context;// O contexto do banco de dados é uma classe que herda de DbContext e representa uma sessão com o banco de dados, permitindo que você consulte e salve instâncias de suas entidades.

        public PagamentosController(AppDbContext context)// O construtor da classe PagamentosController recebe um objeto do tipo AppDbContext, que é o contexto do banco de dados
        {
            _context = context;
        }

        [HttpGet] // Atributo que indica que o método GetPagamentos responde a requisições HTTP GET
        public async Task<ActionResult<IEnumerable<Pago>>> GetPagamentos() // O método GetPagamentos é um método assíncrono que retorna uma lista de objetos do tipo Pago
        {
            return await _context.Pagamentos.ToListAsync();
        }
         
        [HttpGet("{id}")] // Atributo que indica que o método GetPagamento responde a requisições HTTP GET e recebe um parâmetro chamado id
        public async Task<ActionResult<Pago>> GetPagamento(int id) // O método GetPagamento é um método assíncrono que retorna um objeto do tipo Pago
        {
            var pagamento = await _context.Pagamentos.FindAsync(id); // O método FindAsync do contexto do banco de dados retorna um objeto do tipo Pago com base no id passado como parâmetro

            if (pagamento == null) // Se o pagamento não for encontrado, o método retorna um resultado NotFound
            {
                return NotFound(); // NotFound é um método da classe ControllerBase que retorna um resultado 404 Not Found
            }

            return pagamento; // Se o pagamento for encontrado, o método retorna o pagamento
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> PostPagamento(Pago pagamento) // O método PostPagamento é um método assíncrono que recebe um objeto do tipo Pago como parâmetro
        {
            _context.Pagamentos.Add(pagamento);// O método Add do contexto do banco de dados adiciona o pagamento ao contexto
            await _context.SaveChangesAsync();// O método SaveChangesAsync do contexto do banco de dados salva as alterações no banco de dados

            return CreatedAtAction(nameof(GetPagamento), new { id = pagamento.Id }, pagamento); // O método CreatedAtAction da classe ControllerBase retorna um resultado 201 Created com o pagamento criado
        }
    }
}