using Microsoft.EntityFrameworkCore.Migrations;

namespace DeadLine9.DAL.Migrations
{
    public partial class addlikelession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Lessions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Lessions");
        }
    }
}
