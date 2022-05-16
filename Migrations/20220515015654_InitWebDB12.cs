using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bvdd_Hinh_duongdan",
                table: "BaiViet_DiaDiem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bvdd_Hinh_duongdan",
                table: "BaiViet_DiaDiem");
        }
    }
}
