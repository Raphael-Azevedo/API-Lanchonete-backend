namespace Lanche_Bom.Repository.Interfaces
{
    public interface IUnityOfWork
    {
        IItemPedidoRepository ItemPedidoRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        Task Commit();
    }
}