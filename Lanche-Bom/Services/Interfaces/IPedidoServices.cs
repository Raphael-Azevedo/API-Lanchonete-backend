using Lanche_Bom.DTO;
using Lanche_Bom.Models;

namespace Lanche_Bom.Services.Interfaces
{
    public interface IPedidoServices
    {
        Task<IEnumerable<Pedido>> GetAllPedido();
        Task<Decimal?> Create(PedidoDTO pedidoDTO);
        Task Delete(int id);
        Task Update(int id, PedidoDTO pedidoDTO);
    }
}