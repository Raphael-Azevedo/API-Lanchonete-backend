namespace Lanche_Bom.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entitiy);
    }
}