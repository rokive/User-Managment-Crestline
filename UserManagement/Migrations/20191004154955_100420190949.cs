using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class _100420190949 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UserInformations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isConfirm",
                table: "UserInformations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserInformations");

            migrationBuilder.DropColumn(
                name: "isConfirm",
                table: "UserInformations");
        }
    }
}
