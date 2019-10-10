using FileManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.DataAccess.EntityConfigurations
{
    public class FileOutConfiguration : IEntityTypeConfiguration<FileOut>
    {
        public void Configure(EntityTypeBuilder<FileOut> builder)
        {
            builder.ToTable("APIScheduleOut");
            builder.Property(f => f.SapId).HasColumnName("sap_id");
            builder.Property(f => f.ActivityId).HasColumnName("activity_id");
            builder.Property(f => f.ResourceCode).HasColumnName("resource_code");
            builder.Property(f => f.ResourceQuantity).HasColumnName("resource_quantity");
            builder.Ignore(f => f.LockVersion);
        }
    }
}
