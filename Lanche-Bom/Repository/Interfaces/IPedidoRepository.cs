using Lanche_Bom.Models;

namespace Lanche_Bom.Repository.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> GetById(int Id);
        Task<IEnumerable<Pedido>> GetAllPedidos();
    }
}