using System.Linq.Expressions;

namespace Restaurant.Application.Common.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
        
    Task<List<T>> GetAllAsync();

    Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

    Task<T> FindAsync(Expression<Func<T, bool>> predicate);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<T> DeleteAsync(T entity);

    Task<int> CountAsync();

    Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate);
}