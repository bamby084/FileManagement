using FileManagement.DataAccess.Entities;

namespace FileManagement.DataAccess
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> CreateRepository<TEntity>() where TEntity: BaseEntity;
    }
}
