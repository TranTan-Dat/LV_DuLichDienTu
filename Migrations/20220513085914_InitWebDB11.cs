using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dv_hinh_duongdan",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dv_tieude",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dv_hinh_duongdan",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "dv_tieude",
                table: "DichVu");
        }
    }
}
