using Lanche_Bom.Context;
using Lanche_Bom.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanche_Bom.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Get()
        {
            return _context.Set<T>()
                     .AsNoTracking();
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}