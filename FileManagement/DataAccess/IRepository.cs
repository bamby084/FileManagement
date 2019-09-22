using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;

namespace FileManagement.DataAccess
{
    public interface IRepository<TEntity>
        where TEntity: BaseEntity
    {
        IQueryable<TEntity> AsQueryable();
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
        Task SaveChangesAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
