using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dv_trungbinhchatluong",
                table: "DichVu",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                 migrationBuilder.DropColumn(
                name: "dv_trungbinhchatluong",
                table: "DichVu");
        }
    }
}
