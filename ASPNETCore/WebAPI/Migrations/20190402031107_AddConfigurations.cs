using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembershipRequests_AspNetUsers_UserId",
                table: "MembershipRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizationRole_Organizations_OrganizationId",
                table: "UserOrganizationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizationRole_OrganizationRoles_RoleId",
                table: "UserOrganizationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizationRole_AspNetUsers_UserId",
                table: "UserOrganizationRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrganizationRole",
                table: "UserOrganizationRole");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserOrganizationRole",
                newName: "UserOrganizationRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizationRole_UserId",
                table: "UserOrganizationRoles",
                newName: "IX_UserOrganizationRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizationRole_RoleId",
                table: "UserOrganizationRoles",
                newName: "IX_UserOrganizationRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizationRole_OrganizationId",
                table: "UserOrganizationRoles",
                newName: "IX_UserOrganizationRoles_OrganizationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrganizationRoles",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MembershipRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserOrganizationRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrganizationRoles",
                table: "UserOrganizationRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipRequests_AspNetUsers_UserId",
                table: "MembershipRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizationRoles_Organizations_OrganizationId",
                table: "UserOrganizationRoles",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizationRoles_OrganizationRoles_RoleId",
                table: "UserOrganizationRoles",
                column: "RoleId",
                principalTable: "OrganizationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizationRoles_AspNetUsers_UserId",
                table: "UserOrganizationRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembershipRequests_AspNetUsers_UserId",
                table: "MembershipRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizationRoles_Organizations_OrganizationId",
                table: "UserOrganizationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizationRoles_OrganizationRoles_RoleId",
                table: "UserOrganizationRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizationRoles_AspNetUsers_UserId",
                table: "UserOrganizationRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrganizationRoles",
                table: "UserOrganizationRoles");

            migrationBuilder.RenameTable(
                name: "UserOrganizationRoles",
                newName: "UserOrganizationRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizationRoles_UserId",
                table: "UserOrganizationRole",
                newName: "IX_UserOrganizationRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizationRoles_RoleId",
                table: "UserOrganizationRole",
                newName: "IX_UserOrganizationRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizationRoles_OrganizationId",
                table: "UserOrganizationRole",
                newName: "IX_UserOrganizationRole_OrganizationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrganizationRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MembershipRequests",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserOrganizationRole",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrganizationRole",
                table: "UserOrganizationRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipRequests_AspNetUsers_UserId",
                table: "MembershipRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizationRole_Organizations_OrganizationId",
                table: "UserOrganizationRole",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizationRole_OrganizationRoles_RoleId",
                table: "UserOrganizationRole",
                column: "RoleId",
                principalTable: "OrganizationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizationRole_AspNetUsers_UserId",
                table: "UserOrganizationRole",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
