using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.DataAccess
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DbContext _dbContext;
        public RepositoryFactory(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<TEntity> CreateRepository<TEntity>() 
            where TEntity : BaseEntity
        {
            return new Repository<TEntity>(_dbContext);
        }
    }
}
