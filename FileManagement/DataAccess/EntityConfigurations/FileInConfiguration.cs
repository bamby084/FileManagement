using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.DataAccess.EntityConfigurations
{
    public class FileInConfiguration : IEntityTypeConfiguration<FileIn>
    {
        public void Configure(EntityTypeBuilder<FileIn> builder)
        {
            builder.ToTable("APIScheduleIn");
        }
    }
}
