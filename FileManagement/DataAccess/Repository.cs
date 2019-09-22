
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.DataAccess
{
    public class Repository<TEntity>: IRepository<TEntity>
        where TEntity: BaseEntity
    {
        private readonly DbContext _dbContext;
        private DbSet<TEntity> _entities;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }
    }
}
