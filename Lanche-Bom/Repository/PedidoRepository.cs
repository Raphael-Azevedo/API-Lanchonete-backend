using Lanche_Bom.Context;
using Lanche_Bom.Models;
using Lanche_Bom.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanche_Bom.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Pedido> GetById(int Id)
        {
            return await _context.Set<Pedido>()
                            .FirstAsync(item => item.Id == Id);
        }
        public async Task<IEnumerable<Pedido>> GetAllPedidos()
        {
            return await _context.Set<Pedido>()
                        .Include(itens => itens.ItensPedido)
                        .ToListAsync();
        }
    }
}