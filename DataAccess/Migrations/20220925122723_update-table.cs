using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_OperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_UserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.RenameColumn(
                name: "UserTypeName",
                schema: "dbo",
                table: "AppUserTypes",
                newName: "AppUserTypeName");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "AppUserTypeId");

            migrationBuilder.RenameColumn(
                name: "OperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "AppOperationClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserTypeAppOperationClaims_UserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "IX_AppUserTypeAppOperationClaims_AppUserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserTypeAppOperationClaims_OperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "IX_AppUserTypeAppOperationClaims_AppOperationClaimId");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                schema: "dbo",
                table: "AppUsers",
                newName: "AppUserTypeId");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 9, 25, 15, 27, 22, 822, DateTimeKind.Local).AddTicks(6014), new byte[] { 142, 80, 15, 162, 209, 5, 94, 157, 159, 17, 223, 227, 144, 146, 187, 177, 149, 186, 150, 247, 181, 48, 69, 79, 160, 69, 166, 42, 237, 78, 179, 2, 82, 214, 35, 15, 120, 200, 214, 15, 243, 55, 20, 97, 155, 154, 106, 55, 240, 40, 90, 119, 62, 69, 228, 34, 48, 10, 255, 163, 6, 48, 123, 37 }, new byte[] { 214, 188, 141, 238, 207, 168, 40, 146, 228, 190, 206, 235, 16, 210, 243, 96, 58, 147, 254, 186, 26, 151, 93, 25, 85, 130, 191, 121, 83, 225, 0, 33, 147, 200, 111, 213, 129, 20, 237, 172, 15, 87, 45, 76, 248, 82, 30, 186, 162, 59, 137, 180, 46, 2, 133, 18, 50, 15, 25, 2, 183, 108, 150, 87, 48, 118, 0, 113, 68, 43, 24, 156, 233, 237, 136, 95, 37, 41, 98, 215, 154, 46, 217, 139, 181, 36, 172, 244, 178, 252, 229, 186, 38, 232, 189, 216, 99, 181, 211, 195, 128, 243, 199, 31, 112, 8, 189, 209, 210, 187, 84, 222, 137, 215, 57, 100, 128, 140, 152, 105, 17, 151, 141, 153, 238, 141, 161, 204 }, new Guid("a83cd83c-4e0b-4095-9f03-4240ec52000d") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 9, 25, 15, 27, 22, 821, DateTimeKind.Local).AddTicks(5735), new byte[] { 142, 80, 15, 162, 209, 5, 94, 157, 159, 17, 223, 227, 144, 146, 187, 177, 149, 186, 150, 247, 181, 48, 69, 79, 160, 69, 166, 42, 237, 78, 179, 2, 82, 214, 35, 15, 120, 200, 214, 15, 243, 55, 20, 97, 155, 154, 106, 55, 240, 40, 90, 119, 62, 69, 228, 34, 48, 10, 255, 163, 6, 48, 123, 37 }, new byte[] { 214, 188, 141, 238, 207, 168, 40, 146, 228, 190, 206, 235, 16, 210, 243, 96, 58, 147, 254, 186, 26, 151, 93, 25, 85, 130, 191, 121, 83, 225, 0, 33, 147, 200, 111, 213, 129, 20, 237, 172, 15, 87, 45, 76, 248, 82, 30, 186, 162, 59, 137, 180, 46, 2, 133, 18, 50, 15, 25, 2, 183, 108, 150, 87, 48, 118, 0, 113, 68, 43, 24, 156, 233, 237, 136, 95, 37, 41, 98, 215, 154, 46, 217, 139, 181, 36, 172, 244, 178, 252, 229, 186, 38, 232, 189, 216, 99, 181, 211, 195, 128, 243, 199, 31, 112, 8, 189, 209, 210, 187, 84, 222, 137, 215, 57, 100, 128, 140, 152, 105, 17, 151, 141, 153, 238, 141, 161, 204 }, new Guid("dfdc6b15-b360-46c7-ae73-251f36b01f7b") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppUserTypeId",
                schema: "dbo",
                table: "AppUsers",
                column: "AppUserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUserTypes_AppUserTypeId",
                schema: "dbo",
                table: "AppUsers",
                column: "AppUserTypeId",
                principalSchema: "dbo",
                principalTable: "AppUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_AppOperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppOperationClaimId",
                principalSchema: "dbo",
                principalTable: "AppOperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_AppUserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserTypeId",
                principalSchema: "dbo",
                principalTable: "AppUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserTypes_AppUserTypeId",
                schema: "dbo",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_AppOperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_AppUserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppUserTypeId",
                schema: "dbo",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserTypeName",
                schema: "dbo",
                table: "AppUserTypes",
                newName: "UserTypeName");

            migrationBuilder.RenameColumn(
                name: "AppUserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "UserTypeId");

            migrationBuilder.RenameColumn(
                name: "AppOperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "OperationClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "IX_AppUserTypeAppOperationClaims_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppOperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                newName: "IX_AppUserTypeAppOperationClaims_OperationClaimId");

            migrationBuilder.RenameColumn(
                name: "AppUserTypeId",
                schema: "dbo",
                table: "AppUsers",
                newName: "UserTypeId");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 7, 9, 162, DateTimeKind.Local).AddTicks(375), new byte[] { 80, 208, 214, 94, 233, 28, 227, 183, 190, 129, 53, 243, 48, 46, 59, 89, 134, 0, 100, 245, 157, 112, 208, 212, 30, 5, 44, 213, 88, 164, 174, 185, 135, 162, 120, 255, 14, 44, 126, 8, 146, 93, 46, 177, 72, 162, 177, 79, 18, 19, 171, 35, 59, 204, 59, 251, 192, 58, 38, 24, 152, 64, 76, 40 }, new byte[] { 180, 168, 21, 194, 44, 24, 25, 233, 184, 11, 10, 172, 4, 203, 146, 95, 40, 179, 144, 51, 153, 67, 138, 222, 95, 29, 198, 60, 44, 232, 76, 218, 25, 253, 56, 101, 107, 122, 9, 74, 144, 44, 2, 42, 239, 27, 85, 83, 210, 42, 35, 236, 215, 66, 202, 42, 235, 121, 17, 119, 27, 81, 12, 98, 41, 75, 189, 11, 202, 238, 194, 122, 193, 25, 248, 146, 134, 57, 255, 31, 245, 55, 48, 36, 168, 128, 198, 104, 176, 55, 16, 189, 31, 192, 128, 244, 197, 34, 2, 112, 156, 195, 38, 245, 194, 125, 154, 141, 231, 8, 52, 156, 17, 12, 135, 216, 188, 139, 49, 76, 109, 105, 114, 216, 165, 56, 27, 66 }, new Guid("d4f2c0c1-d0d8-4e52-b588-91b0729c2da1") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 7, 9, 160, DateTimeKind.Local).AddTicks(9789), new byte[] { 80, 208, 214, 94, 233, 28, 227, 183, 190, 129, 53, 243, 48, 46, 59, 89, 134, 0, 100, 245, 157, 112, 208, 212, 30, 5, 44, 213, 88, 164, 174, 185, 135, 162, 120, 255, 14, 44, 126, 8, 146, 93, 46, 177, 72, 162, 177, 79, 18, 19, 171, 35, 59, 204, 59, 251, 192, 58, 38, 24, 152, 64, 76, 40 }, new byte[] { 180, 168, 21, 194, 44, 24, 25, 233, 184, 11, 10, 172, 4, 203, 146, 95, 40, 179, 144, 51, 153, 67, 138, 222, 95, 29, 198, 60, 44, 232, 76, 218, 25, 253, 56, 101, 107, 122, 9, 74, 144, 44, 2, 42, 239, 27, 85, 83, 210, 42, 35, 236, 215, 66, 202, 42, 235, 121, 17, 119, 27, 81, 12, 98, 41, 75, 189, 11, 202, 238, 194, 122, 193, 25, 248, 146, 134, 57, 255, 31, 245, 55, 48, 36, 168, 128, 198, 104, 176, 55, 16, 189, 31, 192, 128, 244, 197, 34, 2, 112, 156, 195, 38, 245, 194, 125, 154, 141, 231, 8, 52, 156, 17, 12, 135, 216, 188, 139, 49, 76, 109, 105, 114, 216, 165, 56, 27, 66 }, new Guid("7e1ce3a4-0e0d-40ef-9d81-1395914d0787") });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_OperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "OperationClaimId",
                principalSchema: "dbo",
                principalTable: "AppOperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_UserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "UserTypeId",
                principalSchema: "dbo",
                principalTable: "AppUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
