using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produtos.api.Data;
using Produtos.api.Models;


namespace Products.API.Controllers;

[Route("api/[controller]")] // Define a rota base para o controller
[ApiController]
public class ProdutosController : ControllerBase // Define a classe ProdutosController que herda de ControllerBase
{
    private readonly AppDbContext _context; // Define um campo privado do tipo AppDbContext

    public ProdutosController(AppDbContext context)// Define o construtor da classe ProdutosController que recebe um objeto do tipo AppDbContext
    {
        _context = context; // Inicializa o campo _context com o valor passado como parâmetro
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()// Define a ação GetProdutos
    {
        return await _context.Produtos.ToListAsync();// Retorna a lista de produtos
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id) // Define a ação GetProduto passando o id como parâmetro
    {
        var produto = await _context.Produtos.FindAsync(id);    // Busca o produto pelo id

        if (produto == null) // Se o produto não for encontrado
            return NotFound(); // Retorna 404 Not Found

        return produto; // Retorna o produto
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto) // Define a ação PostProduto passando um objeto do tipo Produto como parâmetro
    {
        _context.Produtos.Add(produto); // Adiciona o produto ao contexto
        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto); // Retorna 201 Created e a URI do novo recurso
    }

    [HttpPut("{id}")]// Define a rota para a ação PutProduto
    public async Task<IActionResult> PutProduto(int id, Produto produto)// Define a ação PutProduto
    { 
        if (id != produto.Id) // Se o id passado como parâmetro for diferente do id do produto
            return BadRequest(); // Retorna 400 Bad Request

        _context.Entry(produto).State = EntityState.Modified; // Define o estado da entidade como modificado

        try
        {
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        }
        catch (DbUpdateConcurrencyException) // Se ocorrer uma exceção de concorrência
        {
            if (!_context.Produtos.Any(e => e.Id == id)) // Se o produto não for encontrado 
                return NotFound(); // Retorna 404 Not Found
            else // Se o produto for encontrado
                throw; // Lança a exceção
        }

        return NoContent(); // Retorna 204 No Content
    }

    [HttpDelete("{id}")] // Define a rota para a ação DeleteProduto
    public async Task<IActionResult> DeleteProduto(int id)// Define a ação DeleteProduto
    {
        var produto = await _context.Produtos.FindAsync(id);// Busca o produto pelo id
        if (produto == null)// Se o produto não for encontrado
            return NotFound(); // Retorna 404 Not Found

        _context.Produtos.Remove(produto);// Remove o produto
        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

        return NoContent();// Retorna 204 No Content
    }
}
