using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateTableAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUsers_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "AppUser");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppOperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "AppUserTypeAppOperationClaim" },
                    { 3, "AppUserType" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -1, 1, "1111", null, null, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 21, 4, 257, DateTimeKind.Local).AddTicks(8171), new byte[] { 46, 98, 61, 15, 248, 253, 61, 174, 9, 69, 179, 70, 222, 213, 140, 13, 207, 153, 143, 117, 108, 220, 238, 72, 24, 250, 244, 146, 114, 62, 134, 51, 133, 106, 111, 5, 190, 141, 70, 82, 139, 97, 102, 140, 110, 34, 69, 159, 70, 184, 184, 221, 92, 246, 65, 61, 100, 161, 19, 57, 186, 191, 47, 141 }, new byte[] { 170, 130, 255, 26, 103, 157, 237, 146, 140, 93, 173, 170, 124, 200, 248, 131, 102, 200, 100, 91, 195, 161, 30, 235, 55, 201, 71, 67, 34, 253, 63, 220, 47, 186, 87, 233, 139, 227, 98, 23, 125, 37, 117, 67, 221, 34, 40, 253, 89, 247, 229, 68, 44, 87, 128, 136, 14, 197, 34, 200, 223, 211, 199, 143, 36, 29, 140, 92, 177, 104, 113, 119, 14, 147, 6, 187, 235, 49, 69, 203, 174, 206, 57, 196, 170, 63, 93, 242, 189, 47, 194, 7, 14, 123, 41, 187, 51, 172, 241, 145, 35, 225, 154, 146, 122, 147, 192, 17, 227, 66, 167, 138, 93, 174, 235, 71, 136, 146, 4, 240, 218, 117, 211, 10, 231, 235, 100, 223 }, new Guid("6a48b7f0-7255-46ee-bef0-713e8e2d736e") });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -2, 2, "1111", null, null, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -3, 3, "1111", null, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Crud");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "AppUserId", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { 1, null, 1, "1111", null, null, 2 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 6, 5, 16, 47, 43, 370, DateTimeKind.Local).AddTicks(8621), new byte[] { 76, 198, 244, 70, 152, 75, 169, 185, 47, 103, 53, 68, 73, 195, 52, 36, 93, 249, 36, 255, 134, 19, 185, 90, 207, 34, 139, 90, 208, 179, 190, 3, 226, 110, 140, 76, 108, 201, 8, 61, 17, 59, 90, 235, 73, 255, 203, 174, 179, 169, 251, 30, 150, 131, 180, 47, 237, 44, 236, 177, 193, 129, 63, 208 }, new byte[] { 51, 190, 166, 25, 100, 241, 152, 74, 19, 211, 226, 26, 98, 214, 231, 39, 5, 16, 35, 244, 44, 183, 147, 103, 7, 140, 241, 167, 81, 20, 65, 3, 95, 162, 126, 225, 85, 198, 204, 25, 150, 207, 87, 108, 147, 153, 40, 37, 158, 144, 109, 85, 114, 151, 87, 79, 68, 4, 152, 89, 136, 164, 139, 35, 14, 100, 8, 13, 136, 179, 135, 118, 36, 106, 220, 22, 22, 83, 216, 37, 90, 56, 231, 230, 47, 183, 226, 12, 17, 222, 5, 198, 76, 5, 183, 31, 82, 206, 108, 160, 67, 141, 236, 232, 51, 126, 51, 12, 215, 248, 235, 149, 123, 148, 82, 207, 253, 18, 197, 153, 17, 190, 231, 65, 6, 159, 28, 46 }, new Guid("27db00fc-25be-48b1-b0fc-bb62702cff72") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUsers_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserId",
                principalSchema: "dbo",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
