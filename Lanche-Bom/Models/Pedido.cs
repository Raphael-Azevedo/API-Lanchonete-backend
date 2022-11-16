using System.ComponentModel.DataAnnotations.Schema;

namespace Lanche_Bom.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<ItemPedido>? ItensPedido { get; set; }
        public decimal? TotalPagar { get; set; }
    }
}