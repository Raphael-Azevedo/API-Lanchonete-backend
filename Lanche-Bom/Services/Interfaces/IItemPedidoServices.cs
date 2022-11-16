using Lanche_Bom.Models;

namespace Lanche_Bom.Services.Interfaces
{
    public interface IItemPedidoServices 
    {
       Task<IEnumerable<ItemPedido>> GetAllItemPedido();
       Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaLanches();
       Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaAdicionais();
    }
}