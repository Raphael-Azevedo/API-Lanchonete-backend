using System.ComponentModel.DataAnnotations;

namespace Lanche_Bom.DTO
{
    public class PedidoDTO
    {
        [Required(ErrorMessage = "This attribute is required!")]
        public List<int>? ItensPedidoId { get; set; }
    }
}