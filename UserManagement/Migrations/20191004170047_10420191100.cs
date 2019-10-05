using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class _10420191100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInformations",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_UserName",
                table: "UserInformations",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInformations_UserName",
                table: "UserInformations");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInformations",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
