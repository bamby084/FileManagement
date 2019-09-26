using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileManagement.Common.Services;
using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.DataAccess
{
    public class Repository<TEntity>: IRepository<TEntity>
        where TEntity: BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly ICredentialService _credentialService;
        private DbSet<TEntity> _entities;
        
        public Repository(DbContext dbContext, ICredentialService credentialService)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
            _credentialService = credentialService;
        }

        public void Add(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;
            entity.CreatedBy = _credentialService.GetCurrentUserId();
            entity.UpdatedBy = _credentialService.GetCurrentUserId();

            _entities.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;
            entity.CreatedBy = _credentialService.GetCurrentUserId();
            entity.UpdatedBy = _credentialService.GetCurrentUserId();

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
            entity.UpdatedBy = _credentialService.GetCurrentUserId();
            entity.UpdatedOn = DateTime.UtcNow;

            _entities.Update(entity);
        }
    }
}
