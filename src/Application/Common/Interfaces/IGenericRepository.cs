using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurant.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        void DetachAllEntities();
        IEnumerable<T> SqlQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, new();
        
        void BeginTransaction();
        Task<bool> CommitTransactionAsync();
        
        bool CommitTransaction();
        void RollbackTransaction();
        
        Task<bool> SaveAsync();
        bool Save();
        
        bool Remove(T entity);
        bool Remove(object id);
        
        bool AddRange(IEnumerable<T> entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entity);
        
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        bool Delete(object id);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);
        bool Delete(Expression<Func<T, bool>> filter);
        Task<bool> DeleteAsync(object id);
        
        int Count();
        int Count(Expression<Func<T, bool>> filter);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> filter);
        
        T Get(Expression<Func<T, bool>> filter);
        T FirstOrDefault(Expression<Func<T, bool>> filter = null);
        T LastOrDefault(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
    }
}