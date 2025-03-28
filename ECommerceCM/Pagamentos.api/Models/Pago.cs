using Microsoft.AspNetCore.Identity;

namespace Pagamentos.api.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }  // Relacionamento com o Pedido
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } // Exemplo: "Pago", "Pendente"
    }
}
