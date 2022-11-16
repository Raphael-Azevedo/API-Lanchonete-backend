using Lanche_Bom.DTO;
using Lanche_Bom.Models;
using Lanche_Bom.Repository.Interfaces;
using Lanche_Bom.Services.Interfaces;

namespace Lanche_Bom.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IUnityOfWork _uof;

        public PedidoServices(IUnityOfWork uof)
        {
            _uof = uof;
        }

        public async Task<Decimal?> Create(PedidoDTO pedidoDTO)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido.ItensPedido = await _uof.ItemPedidoRepository.GetItensPedidos(pedidoDTO.ItensPedidoId);
                VerificarDuplicidadeDeItensPedido(pedido, pedidoDTO);
                pedido.TotalPagar = DescontoDoValorTotal(pedido);
                await _uof.PedidoRepository.Add(pedido);
                await _uof.Commit();
                return  pedido.TotalPagar;
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public async Task Delete(int id)
        {
            var pedido = await _uof.PedidoRepository.GetById(id);
            if (pedido.Id == id)
            {
                _uof.PedidoRepository.Delete(pedido);
                await _uof.Commit();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<IEnumerable<Pedido>> GetAllPedido()
        {
            return await _uof.PedidoRepository.GetAllPedidos();
        }

        public async Task Update(int id, PedidoDTO pedidoDTO)
        {
            try
            {
                var pedido = await _uof.PedidoRepository.GetById(id);
                pedido.ItensPedido = await _uof.ItemPedidoRepository.GetItensPedidos(pedidoDTO.ItensPedidoId);
                VerificarDuplicidadeDeItensPedido(pedido, pedidoDTO);
                pedido.TotalPagar = DescontoDoValorTotal(pedido);
                await Delete(pedido.Id);
                await _uof.PedidoRepository.Add(pedido);
                await _uof.Commit();
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        private Decimal? DescontoDoValorTotal(Pedido pedido)
        {
            pedido.TotalPagar = pedido.ItensPedido.Sum(c => c.Preco);

            if (pedido.ItensPedido.Any(item => item.Categoria.Contains("Lanche")) && pedido.ItensPedido.Any(nome => nome.Nome.Contains("Refrigerante")) && pedido.ItensPedido.Any(nome2 => nome2.Nome.Contains("Batata Frita")))
            {
                pedido.TotalPagar = pedido.TotalPagar * 0.80M;
                return pedido.TotalPagar;
            }
            if (pedido.ItensPedido.Any(item => item.Categoria == "Lanche") && pedido.ItensPedido.Any(nome => nome.Nome == "Refrigerante") && pedido.ItensPedido.Count() == 2)
            {
                pedido.TotalPagar = pedido.TotalPagar * 0.85M;
                return pedido.TotalPagar;
            }
            if (pedido.ItensPedido.Any(item => item.Categoria == "Lanche") && pedido.ItensPedido.Any(nome => nome.Nome == "Batata Frita" && pedido.ItensPedido.Count() == 2))
            {
                pedido.TotalPagar = pedido.TotalPagar * 0.90M;
                return pedido.TotalPagar;
            }
            else
            {
                return pedido.TotalPagar;
            }
        }

        private void VerificarDuplicidadeDeItensPedido(Pedido pedido, PedidoDTO pedidoDTO)
        {
            if (pedido.ItensPedido.Where(i => i.Categoria == "Lanche").Count() > 1)
            {
                throw new InvalidOperationException("Pedido com mais de um Lanche!");
            }
            if (pedidoDTO.ItensPedidoId.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException("Pedido com itens repetidos!");
            }
        }
    }
}