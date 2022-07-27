using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GsmNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    UserTypeId = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTypeAppOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalSchema: "dbo",
                        principalTable: "AppOperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalSchema: "dbo",
                        principalTable: "AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppOperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AppUser" },
                    { 2, "AppUserTypeAppOperationClaim" },
                    { 3, "AppUserType" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[,]
                {
                    { -1, "System Admin" },
                    { -2, "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeId" },
                values: new object[,]
                {
                    { -1, new DateTime(2022, 7, 27, 23, 7, 9, 160, DateTimeKind.Local).AddTicks(9789), 1, null, null, "kubi@hot.com", "Kubilay", "", false, "Yazı", new byte[] { 80, 208, 214, 94, 233, 28, 227, 183, 190, 129, 53, 243, 48, 46, 59, 89, 134, 0, 100, 245, 157, 112, 208, 212, 30, 5, 44, 213, 88, 164, 174, 185, 135, 162, 120, 255, 14, 44, 126, 8, 146, 93, 46, 177, 72, 162, 177, 79, 18, 19, 171, 35, 59, 204, 59, 251, 192, 58, 38, 24, 152, 64, 76, 40 }, new byte[] { 180, 168, 21, 194, 44, 24, 25, 233, 184, 11, 10, 172, 4, 203, 146, 95, 40, 179, 144, 51, 153, 67, 138, 222, 95, 29, 198, 60, 44, 232, 76, 218, 25, 253, 56, 101, 107, 122, 9, 74, 144, 44, 2, 42, 239, 27, 85, 83, 210, 42, 35, 236, 215, 66, 202, 42, 235, 121, 17, 119, 27, 81, 12, 98, 41, 75, 189, 11, 202, 238, 194, 122, 193, 25, 248, 146, 134, 57, 255, 31, 245, 55, 48, 36, 168, 128, 198, 104, 176, 55, 16, 189, 31, 192, 128, 244, 197, 34, 2, 112, 156, 195, 38, 245, 194, 125, 154, 141, 231, 8, 52, 156, 17, 12, 135, 216, 188, 139, 49, 76, 109, 105, 114, 216, 165, 56, 27, 66 }, "", new Guid("7e1ce3a4-0e0d-40ef-9d81-1395914d0787"), null, null, "kubilayyazi", -1 },
                    { -2, new DateTime(2022, 7, 27, 23, 7, 9, 162, DateTimeKind.Local).AddTicks(375), 1, null, null, "admin@gmail.com", "Admin", "", false, "ADMIN", new byte[] { 80, 208, 214, 94, 233, 28, 227, 183, 190, 129, 53, 243, 48, 46, 59, 89, 134, 0, 100, 245, 157, 112, 208, 212, 30, 5, 44, 213, 88, 164, 174, 185, 135, 162, 120, 255, 14, 44, 126, 8, 146, 93, 46, 177, 72, 162, 177, 79, 18, 19, 171, 35, 59, 204, 59, 251, 192, 58, 38, 24, 152, 64, 76, 40 }, new byte[] { 180, 168, 21, 194, 44, 24, 25, 233, 184, 11, 10, 172, 4, 203, 146, 95, 40, 179, 144, 51, 153, 67, 138, 222, 95, 29, 198, 60, 44, 232, 76, 218, 25, 253, 56, 101, 107, 122, 9, 74, 144, 44, 2, 42, 239, 27, 85, 83, 210, 42, 35, 236, 215, 66, 202, 42, 235, 121, 17, 119, 27, 81, 12, 98, 41, 75, 189, 11, 202, 238, 194, 122, 193, 25, 248, 146, 134, 57, 255, 31, 245, 55, 48, 36, 168, 128, 198, 104, 176, 55, 16, 189, 31, 192, 128, 244, 197, 34, 2, 112, 156, 195, 38, 245, 194, 125, 154, 141, 231, 8, 52, 156, 17, 12, 135, 216, 188, 139, 49, 76, 109, 105, 114, 216, 165, 56, 27, 66 }, "", new Guid("d4f2c0c1-d0d8-4e52-b588-91b0729c2da1"), null, null, "admin", -2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -1, 1, "1011", null, null, -2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -2, 2, "1111", null, null, -2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -3, 3, "1111", null, null, -2 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_OperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_UserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypes",
                schema: "dbo");
        }
    }
}
