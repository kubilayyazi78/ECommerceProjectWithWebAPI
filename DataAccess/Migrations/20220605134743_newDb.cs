using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class newDb : Migration
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
                    AppUserId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AppUserTypeAppOperationClaims_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[] { 1, "Crud" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[,]
                {
                    { 1, "System Admin" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeId" },
                values: new object[] { 1, new DateTime(2022, 6, 5, 16, 47, 43, 370, DateTimeKind.Local).AddTicks(8621), 1, null, null, "kubi@hot.com", "Kubilay", "", false, "Yazı", new byte[] { 76, 198, 244, 70, 152, 75, 169, 185, 47, 103, 53, 68, 73, 195, 52, 36, 93, 249, 36, 255, 134, 19, 185, 90, 207, 34, 139, 90, 208, 179, 190, 3, 226, 110, 140, 76, 108, 201, 8, 61, 17, 59, 90, 235, 73, 255, 203, 174, 179, 169, 251, 30, 150, 131, 180, 47, 237, 44, 236, 177, 193, 129, 63, 208 }, new byte[] { 51, 190, 166, 25, 100, 241, 152, 74, 19, 211, 226, 26, 98, 214, 231, 39, 5, 16, 35, 244, 44, 183, 147, 103, 7, 140, 241, 167, 81, 20, 65, 3, 95, 162, 126, 225, 85, 198, 204, 25, 150, 207, 87, 108, 147, 153, 40, 37, 158, 144, 109, 85, 114, 151, 87, 79, 68, 4, 152, 89, 136, 164, 139, 35, 14, 100, 8, 13, 136, 179, 135, 118, 36, 106, 220, 22, 22, 83, 216, 37, 90, 56, 231, 230, 47, 183, 226, 12, 17, 222, 5, 198, 76, 5, 183, 31, 82, 206, 108, 160, 67, 141, 236, 232, 51, 126, 51, 12, 215, 248, 235, 149, 123, 148, 82, 207, 253, 18, 197, 153, 17, 190, 231, 65, 6, 159, 28, 46 }, "", new Guid("27db00fc-25be-48b1-b0fc-bb62702cff72"), null, null, "kubilayyazi", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "AppUserId", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { 1, null, 1, "1111", null, null, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserId");

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
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypes",
                schema: "dbo");
        }
    }
}
