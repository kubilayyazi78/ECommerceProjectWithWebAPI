﻿// <auto-generated />
using System;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    [Migration("20221216195401_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Concrete.AppOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("AppOperationClaims", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = false,
                            Name = "AppUser"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = false,
                            Name = "AppUserTypeAppOperationClaim"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = false,
                            Name = "AppUserType"
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("AppUserTypeId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("GsmNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("GsmNumber");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("ProfileImageUrl");

                    b.Property<Guid>("RefreshToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("AppUserTypeId");

                    b.ToTable("AppUsers", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AppUserTypeId = -1,
                            CreatedDate = new DateTime(2022, 12, 16, 22, 54, 0, 750, DateTimeKind.Local).AddTicks(3084),
                            CreatedUserId = 1,
                            Email = "sadmin@gmail.com",
                            FirstName = "System",
                            GsmNumber = "",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 222, 105, 224, 85, 191, 216, 48, 219, 197, 90, 174, 209, 61, 19, 108, 207, 204, 223, 41, 176, 139, 65, 32, 220, 15, 181, 230, 126, 204, 42, 67, 219, 254, 6, 238, 156, 114, 127, 31, 174, 180, 249, 51, 102, 136, 217, 52, 185, 37, 149, 100, 29, 220, 3, 61, 100, 185, 8, 201, 195, 29, 149, 109, 101 },
                            PasswordSalt = new byte[] { 13, 114, 52, 184, 70, 89, 18, 10, 114, 76, 5, 55, 96, 143, 16, 154, 159, 227, 150, 16, 70, 221, 138, 254, 8, 168, 242, 54, 14, 151, 134, 47, 107, 136, 155, 83, 69, 155, 4, 241, 21, 211, 245, 105, 160, 28, 217, 65, 123, 202, 245, 211, 199, 102, 245, 102, 149, 31, 104, 207, 69, 203, 197, 80, 150, 236, 141, 253, 97, 48, 18, 83, 28, 96, 206, 108, 197, 164, 144, 77, 108, 179, 236, 159, 51, 2, 117, 99, 16, 130, 216, 120, 210, 253, 142, 139, 46, 31, 161, 111, 253, 203, 5, 36, 144, 251, 198, 209, 37, 252, 145, 229, 104, 32, 73, 139, 48, 231, 134, 194, 190, 148, 52, 125, 166, 1, 94, 228 },
                            ProfileImageUrl = "",
                            RefreshToken = new Guid("f16488ca-cb66-49f3-9c54-91b6cc04afd7"),
                            UserName = "sadmin"
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("AppUserTypeName");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppUserTypes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AppUserTypeName = "System Admin",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 0,
                            IsActive = false,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUserTypeAppOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppOperationClaimId")
                        .HasColumnType("int")
                        .HasColumnName("OperationClaimId");

                    b.Property<int>("AppUserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("char(4)")
                        .HasColumnName("Status");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppOperationClaimId");

                    b.HasIndex("AppUserTypeId");

                    b.ToTable("AppUserTypeAppOperationClaims", "dbo");
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUser", b =>
                {
                    b.HasOne("Core.Entities.Concrete.AppUserType", "AppUserType")
                        .WithMany("AppUsers")
                        .HasForeignKey("AppUserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUserType");
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUserTypeAppOperationClaim", b =>
                {
                    b.HasOne("Core.Entities.Concrete.AppOperationClaim", "AppOperationClaim")
                        .WithMany("AppUserTypeAppOperationClaims")
                        .HasForeignKey("AppOperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.AppUserType", "AppUserType")
                        .WithMany("AppUserTypeAppOperationClaims")
                        .HasForeignKey("AppUserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppOperationClaim");

                    b.Navigation("AppUserType");
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppOperationClaim", b =>
                {
                    b.Navigation("AppUserTypeAppOperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.AppUserType", b =>
                {
                    b.Navigation("AppUsers");

                    b.Navigation("AppUserTypeAppOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}