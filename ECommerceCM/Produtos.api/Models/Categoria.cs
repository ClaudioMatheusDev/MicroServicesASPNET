using Produtos.api.Models;

namespace Produtos.api.Models 
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; } //ICollection é uma interface que representa uma coleção de objetos que podem ser lidos e iterados
    }
}