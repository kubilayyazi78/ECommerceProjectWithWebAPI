using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Core.Entities.Enums;
using Core.Utilities.Security.Hash.Sha512;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUserType>
    {
        public void Configure(EntityTypeBuilder<AppUserType> builder)
        {
            builder.ToTable("AppUserTypes", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AppUserTypeName)
                .HasColumnName("AppUserTypeName")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new AppUserType() { Id = -1, AppUserTypeName = "System Admin" },
                new AppUserType() { Id = -2, AppUserTypeName = "Admin" }
            );

        }
    }
}
