using Module.Bases.Domain.Models;
using System.Linq.Expressions;

namespace Module.Bases.Domain.Stores
{
    public interface IBaseStore<T> where T : BaseEntity, new()
    {
        Task<T?> GetByIdAsync(string id);
        Task<List<T>> Find(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }
}
