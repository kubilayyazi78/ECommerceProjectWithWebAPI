using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Core.Entities.Enums;
using Core.Utilities.Security.Hash.Sha512;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppOperationClaimConfiguration:IEntityTypeConfiguration<AppOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AppOperationClaim> builder)
        {
            builder.ToTable("AppOperationClaims", @"dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();


        }
    }
}
