using Lanche_Bom.Context;
using Lanche_Bom.Repository.Interfaces;

namespace Lanche_Bom.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private IItemPedidoRepository? _ItemPedidoRepo;
        private IPedidoRepository? _PedidoRepo;
        private AppDbContext _context;
        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IItemPedidoRepository ItemPedidoRepository
        {
            get
            {
                return _ItemPedidoRepo = _ItemPedidoRepo ?? new ItemPedidoRepository(_context);
            }
        }

        public IPedidoRepository PedidoRepository
        {
            get
            {
                return _PedidoRepo = _PedidoRepo ?? new PedidoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}