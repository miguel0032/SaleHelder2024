

namespace SaleHelder.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task<List<T>> GetAll();   
        Task<T> GetById(int id);
        Task Delete(T entity);
    }
}
