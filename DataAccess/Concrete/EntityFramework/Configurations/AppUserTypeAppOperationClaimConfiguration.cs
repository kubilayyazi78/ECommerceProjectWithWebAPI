using Core.Entities.Concrete;
using Entities.Concrete;
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

            builder.Property(x => x.OperationClaimId)
                .HasColumnName("OperationClaimId")
                .IsRequired();


            builder.Property(x => x.UserTypeId)
                .HasColumnName("UserTypeId")
                .IsRequired();


            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("char(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.HasData(new AppUserTypeAppOperationClaim()
            {
                Id = -1,
                UserTypeId = (int)AppUserTypes.Admin,
                OperationClaimId = 1,
                Status = "1111"
            });
        }
    }
}
