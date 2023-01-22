using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Page");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppOperationClaims",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 2, true, "AppUserType" },
                    { 4, true, "PageType" },
                    { 5, true, "Product" },
                    { 6, true, "ProductType" },
                    { 7, true, "Contact" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 22, 11, 49, 54, 176, DateTimeKind.Local).AddTicks(4946), new byte[] { 56, 237, 149, 214, 83, 158, 251, 192, 97, 101, 61, 34, 163, 32, 10, 51, 217, 26, 70, 45, 99, 242, 11, 241, 40, 32, 224, 94, 165, 20, 116, 136, 90, 197, 211, 216, 68, 5, 201, 255, 215, 203, 109, 205, 175, 9, 96, 139, 119, 69, 64, 60, 147, 84, 137, 20, 243, 197, 129, 210, 239, 176, 12, 117 }, new byte[] { 119, 154, 224, 73, 110, 96, 158, 237, 34, 179, 217, 201, 255, 207, 35, 255, 69, 77, 148, 17, 29, 155, 239, 140, 147, 229, 126, 67, 11, 23, 123, 82, 189, 207, 3, 214, 198, 26, 233, 178, 78, 78, 157, 127, 58, 10, 53, 74, 68, 238, 123, 5, 7, 160, 129, 34, 54, 130, 29, 169, 132, 105, 158, 6, 78, 89, 118, 74, 51, 37, 87, 63, 108, 77, 12, 165, 75, 81, 77, 253, 138, 7, 225, 12, 70, 149, 157, 187, 20, 219, 236, 102, 249, 136, 241, 109, 97, 129, 190, 201, 242, 250, 7, 166, 49, 203, 218, 72, 132, 188, 58, 135, 144, 157, 143, 17, 179, 21, 122, 114, 156, 198, 62, 173, 63, 89, 117, 35 }, new Guid("0ea4e0b2-d5a6-462b-a479-127d5324a33c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "AppUserType");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 18, 23, 43, 8, 798, DateTimeKind.Local).AddTicks(1513), new byte[] { 234, 14, 189, 206, 147, 68, 38, 150, 16, 2, 9, 177, 24, 197, 224, 38, 167, 50, 174, 2, 71, 157, 238, 190, 87, 95, 41, 193, 131, 215, 255, 214, 65, 21, 26, 37, 36, 179, 207, 214, 110, 212, 209, 135, 182, 59, 69, 111, 59, 179, 67, 104, 167, 34, 0, 185, 230, 167, 224, 217, 155, 165, 164, 215 }, new byte[] { 229, 97, 2, 70, 233, 78, 70, 141, 37, 114, 37, 243, 167, 81, 108, 109, 129, 124, 57, 75, 155, 223, 155, 215, 17, 33, 4, 168, 111, 69, 42, 121, 49, 167, 7, 136, 131, 36, 41, 254, 38, 151, 91, 243, 223, 128, 164, 214, 253, 240, 21, 148, 59, 13, 103, 60, 122, 94, 146, 187, 93, 150, 86, 70, 185, 150, 130, 143, 200, 3, 117, 22, 187, 169, 25, 57, 109, 151, 120, 216, 223, 45, 52, 142, 169, 209, 208, 137, 227, 124, 163, 210, 148, 159, 64, 36, 239, 223, 222, 129, 186, 118, 20, 251, 148, 47, 16, 19, 4, 144, 181, 18, 9, 134, 191, 155, 168, 73, 23, 17, 125, 107, 160, 223, 17, 127, 211, 161 }, new Guid("940d3829-9017-4e22-a2a1-7e4ebb681ed2") });
        }
    }
}
