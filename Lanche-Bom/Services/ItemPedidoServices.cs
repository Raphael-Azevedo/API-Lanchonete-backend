using Lanche_Bom.Models;
using Lanche_Bom.Repository.Interfaces;
using Lanche_Bom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanche_Bom.Services
{
    public class ItemPedidoServices : IItemPedidoServices
    {
        private readonly IUnityOfWork _uof;

        public ItemPedidoServices(IUnityOfWork uof)
        {
            _uof = uof;
        }

        public async Task<IEnumerable<ItemPedido>> GetAllItemPedido()
        {
            return await _uof.ItemPedidoRepository.Get().ToListAsync();
        }

        public async Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaAdicionais()
        {
            return await _uof.ItemPedidoRepository.GetItemPedidoCategoriaAdicionais();
        }

        public async Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaLanches()
        {
            return await _uof.ItemPedidoRepository.GetItemPedidoCategoriaLanches();
        }
    }
}