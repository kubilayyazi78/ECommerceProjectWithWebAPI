using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Core.Entities.Enums;
using Core.Utilities.Security.Hash.Sha512;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserTypeAppOperationClaimConfiguration : IEntityTypeConfiguration<AppUserTypeAppOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserTypeAppOperationClaim> builder)
        {
            builder.ToTable("AppUserTypeAppOperationClaims", @"dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AppOperationClaimId)
                .HasColumnName("AppOperationClaimId")
                .IsRequired();


            builder.Property(x => x.AppUserTypeId)
                .HasColumnName("AppUserTypeId")
                .IsRequired();


            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("char(4)")
                .HasMaxLength(4)
                .IsRequired();

            /*
            * Category sayfası
           * CRUD
           * 1111
           * 0111
           */
            builder.HasData(
                new AppUserTypeAppOperationClaim() { Id = -1, AppUserTypeId = (int)AppUserTypes.Admin, AppOperationClaimId = 1, Status = "1011" },
                new AppUserTypeAppOperationClaim() { Id = -2, AppUserTypeId = (int)AppUserTypes.Admin, AppOperationClaimId = 2, Status = "1111" },
                new AppUserTypeAppOperationClaim() { Id = -3, AppUserTypeId = (int)AppUserTypes.Admin, AppOperationClaimId = 3, Status = "1111" });
        }
    }
}
