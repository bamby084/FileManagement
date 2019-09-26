using FileManagement.Common.Services;
using FileManagement.DataAccess.Entities;
using FileManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.DataAccess
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DbContext _dbContext;
        private readonly ICredentialService _credentialService;

        public RepositoryFactory(DbContext dbContext, ICredentialService credentialService)
        {
            _dbContext = dbContext;
            _credentialService = credentialService;
        }
        public IRepository<TEntity> CreateRepository<TEntity>() 
            where TEntity : BaseEntity
        {
            return new Repository<TEntity>(_dbContext, _credentialService);
        }
    }
}
