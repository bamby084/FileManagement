using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.DataAccess.EntityConfigurations
{
    public class UserFileConfiguration : IEntityTypeConfiguration<UserFile>
    {
        public void Configure(EntityTypeBuilder<UserFile> builder)
        {
            builder.ToTable("UserAccount_APIFile")
                .Property(f => f.UserId).HasColumnName("UserAccountId");
        }
    }
}
