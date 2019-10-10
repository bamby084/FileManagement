using FileManagement.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.DataAccess
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new FileInConfiguration())
                .ApplyConfiguration(new FileOutConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
