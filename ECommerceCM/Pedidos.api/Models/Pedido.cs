namespace Pedidos.api.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioID { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.UtcNow; //Data e hora atual do sistema em UTC (Coordinated Universal Time)
        public decimal Total { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>(); // Lista de itens do pedido (ItemPedido) inicializada com uma lista vazia 
    }
}