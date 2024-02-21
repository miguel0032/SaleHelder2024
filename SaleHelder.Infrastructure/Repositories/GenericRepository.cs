

using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using SaleHelder.Application.Interfaces.Repositories;

namespace SaleHelder.Infrastructure.Repositories
{
    public class GenericRepository<T>  : IGenericRepository<T> where T : class
    {
        private readonly DataContext _ctx;
        public GenericRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task Add(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
             _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _ctx.Set<T>().ToListAsync();   
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

        }
    }
}
