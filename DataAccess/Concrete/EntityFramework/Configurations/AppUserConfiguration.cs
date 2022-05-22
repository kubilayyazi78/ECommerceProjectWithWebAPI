using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers", @"dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();


            //builder.Property(x => x.Password)
            //    .HasColumnName("Password")
            //    .HasMaxLength(20)
            //    .IsRequired();

            //builder.Property(x => x.Gender)
            //    .HasColumnName("Gender")
            //    .IsRequired();

            //builder.Property(x => x.DateOfBirth)
            //    .HasColumnName("DateOfBirth")
            //    .IsRequired();

            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasData(new AppUser
            {
                Id = 1,
                FirstName = "Kubilay",
                LastName = "Yazı",
                //Password = "123456",
                //Gender = true,
                //DateOfBirth = Convert.ToDateTime("23-02-1996"),
                CreatedDate = DateTime.Now,
              //  Address = "Karabük",
                CreatedUserId = 1,
                Email = "kubi@hot.com",
                UserName = "kubilayyazi"
            });
        }
    }
}
