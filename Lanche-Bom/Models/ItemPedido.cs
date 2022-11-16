using System.Text.Json.Serialization;

namespace Lanche_Bom.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public string? Categoria { get; set; }
        [JsonIgnore]
        public List<Pedido>? ItensPedido { get; set; }
    }
}