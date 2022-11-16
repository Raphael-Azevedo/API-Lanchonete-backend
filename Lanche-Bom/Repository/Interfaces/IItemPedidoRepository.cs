using Lanche_Bom.Models;

namespace Lanche_Bom.Repository.Interfaces
{
    public interface IItemPedidoRepository : IRepository<ItemPedido>
    {
        Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaAdicionais();
        Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaLanches();
        Task<IEnumerable<ItemPedido>> GetById(int Id);
        Task<List<ItemPedido>> GetItensPedidos(List<int> ids);
    }
}