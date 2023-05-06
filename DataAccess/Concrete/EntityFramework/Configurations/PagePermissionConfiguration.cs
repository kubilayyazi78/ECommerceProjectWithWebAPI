using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class PagePermissionConfiguration:IEntityTypeConfiguration<PagePermission>
    {
        public void Configure(EntityTypeBuilder<PagePermission> builder)
        {
            builder.ToTable("PagePermissons", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PageID)
                .HasColumnName("PageID")
                .IsRequired();

            builder.Property(x => x.UserTypeID)
              .HasColumnName("UserTypeID")
              .IsRequired();

            builder.Property(x => x.OperationClaimID)
             .HasColumnName("OperationClaimID")
             .IsRequired();

            //UserTypeID = 2 Admin
            builder.HasData(
                new PagePermission() { Id = 1, PageID = 2, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 2, PageID = 3, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 3, PageID = 4, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 4, PageID = 5, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 5, PageID = 6, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 6, PageID = 7, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 7, PageID = 8, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 8, PageID = 9, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 9, PageID = 10, UserTypeID = 2, OperationClaimID = 1 },
                new PagePermission() { Id = 10, PageID = 11, UserTypeID = 2, OperationClaimID = 1 }
            );
        }
    }
}
