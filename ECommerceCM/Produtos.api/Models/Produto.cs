namespace Produtos.api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Nome do produto //string.Empty é o mesmo que "" ou null
        public string Categoria { get; set; } = string.Empty; // Categoria do produto //string.Empty é o mesmo que "" ou null
        public decimal Preco   { get; set; }

    }
}
