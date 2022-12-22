using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddPageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    PageSeoUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PageTypeId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_PageTypes_PageTypeId",
                        column: x => x.PageTypeId,
                        principalSchema: "dbo",
                        principalTable: "PageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 12, 22, 22, 9, 38, 250, DateTimeKind.Local).AddTicks(4422), new byte[] { 95, 77, 87, 102, 247, 61, 217, 110, 219, 119, 26, 213, 219, 42, 211, 204, 224, 169, 92, 57, 12, 109, 238, 117, 67, 138, 82, 62, 144, 129, 225, 218, 201, 86, 152, 236, 21, 22, 239, 143, 71, 180, 169, 154, 82, 63, 70, 9, 179, 40, 149, 66, 122, 222, 159, 121, 239, 239, 81, 102, 212, 9, 201, 155 }, new byte[] { 148, 167, 245, 117, 134, 218, 115, 100, 55, 76, 159, 130, 12, 135, 0, 72, 98, 179, 122, 176, 171, 172, 28, 95, 224, 128, 99, 171, 220, 220, 100, 89, 248, 22, 187, 221, 181, 83, 93, 126, 221, 255, 33, 65, 38, 12, 47, 189, 122, 222, 77, 185, 34, 16, 77, 22, 183, 216, 193, 50, 31, 76, 253, 103, 66, 195, 217, 65, 167, 112, 28, 17, 66, 15, 8, 64, 35, 80, 188, 91, 218, 206, 170, 1, 226, 163, 119, 62, 202, 71, 188, 214, 181, 207, 115, 119, 177, 166, 152, 46, 215, 94, 221, 44, 96, 233, 241, 91, 50, 240, 154, 171, 242, 41, 156, 149, 159, 249, 32, 163, 18, 5, 83, 145, 147, 168, 220, 214 }, new Guid("3eff2068-f52b-4ba7-b10d-565ca4265363") });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PageTypes",
                columns: new[] { "Id", "IsActive", "PageTypeName" },
                values: new object[] { 2, true, "Web" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PageTypes",
                columns: new[] { "Id", "IsActive", "PageTypeName" },
                values: new object[] { 1, true, "Admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "MetaDescription", "MetaKeywords", "MetaTitle", "PageName", "PageSeoUrl", "PageTypeId", "PageUrl", "ParentID" },
                values: new object[,]
                {
                    { 1, 1, true, "", "", "", "Sistem Ayarları", "", 1, "#", null },
                    { 2, 1, true, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/List", 1 },
                    { 3, 1, true, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/List", 1 },
                    { 4, 1, true, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/List", 1 },
                    { 5, 1, true, "", "", "", "Sayfa Yetkileri", "", 1, "/Admin/PagePermissons/List", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageTypeId",
                schema: "dbo",
                table: "Pages",
                column: "PageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagePermissions");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PageTypes",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 12, 21, 23, 9, 3, 771, DateTimeKind.Local).AddTicks(3316), new byte[] { 84, 40, 123, 103, 190, 75, 68, 179, 144, 49, 19, 217, 208, 181, 88, 101, 184, 250, 254, 65, 99, 204, 232, 151, 43, 253, 211, 243, 101, 115, 194, 20, 232, 184, 75, 27, 4, 125, 191, 104, 18, 187, 9, 247, 79, 184, 4, 164, 132, 158, 22, 188, 158, 151, 220, 171, 178, 230, 238, 101, 253, 110, 223, 244 }, new byte[] { 131, 120, 46, 174, 184, 138, 167, 88, 26, 47, 1, 45, 21, 251, 90, 80, 234, 22, 150, 16, 7, 111, 216, 220, 123, 85, 220, 15, 230, 184, 50, 40, 159, 39, 20, 134, 63, 15, 210, 165, 57, 236, 37, 87, 134, 236, 125, 155, 236, 119, 242, 81, 247, 159, 143, 166, 126, 198, 33, 29, 169, 83, 213, 133, 65, 192, 125, 210, 58, 240, 63, 141, 143, 213, 19, 122, 245, 238, 176, 196, 112, 120, 180, 108, 149, 45, 179, 190, 5, 252, 78, 47, 38, 182, 76, 224, 237, 103, 32, 2, 33, 184, 9, 108, 120, 84, 114, 165, 123, 198, 15, 70, 112, 137, 174, 131, 235, 245, 91, 3, 40, 215, 206, 103, 72, 20, 25, 237 }, new Guid("1777657d-f4d2-48a0-ac06-568fc5a602d3") });
        }
    }
}
