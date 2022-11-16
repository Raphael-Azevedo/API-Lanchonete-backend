using Lanche_Bom.Context;
using Lanche_Bom.Models;
using Lanche_Bom.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanche_Bom.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaAdicionais()
        {
            return await Get()
                        .Where(cat => cat.Categoria == "Adicional")
                        .ToListAsync();
        }

        public async Task<IEnumerable<ItemPedido>> GetItemPedidoCategoriaLanches()
        {
            return await Get()
                        .Where(cat => cat.Categoria == "Lanche")
                        .ToListAsync();
        }
        public async Task<IEnumerable<ItemPedido>> GetById(int Id)
        {
            return await _context.Set<ItemPedido>()
                            .Where(item => item.Id == Id)
                            .AsNoTracking()
                            .ToListAsync();
        }
        public async Task<List<ItemPedido>> GetItensPedidos(List<int> ids)
        {
            return await _context.Set<ItemPedido>()
                        .Where(item => ids.Contains(item.Id))
                        .ToListAsync();
        }
    }
}