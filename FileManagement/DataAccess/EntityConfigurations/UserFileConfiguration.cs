using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.DataAccess.EntityConfigurations
{
    public class UserFileConfiguration : IEntityTypeConfiguration<UserFile>
    {
        public void Configure(EntityTypeBuilder<UserFile> builder)
        {
        }
    }
}
