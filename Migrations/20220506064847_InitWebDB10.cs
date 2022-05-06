using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DichVu_LoaiDichVu_loaiDichVuldv_id",
                table: "DichVu");

            migrationBuilder.DropIndex(
                name: "IX_DichVu_loaiDichVuldv_id",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "loaiDichVuldv_id",
                table: "DichVu");

            migrationBuilder.AddColumn<string>(
                name: "dv_quanhuyen",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dv_tinhthanh",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_ldv_id",
                table: "DichVu",
                column: "ldv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DichVu_LoaiDichVu_ldv_id",
                table: "DichVu",
                column: "ldv_id",
                principalTable: "LoaiDichVu",
                principalColumn: "ldv_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DichVu_LoaiDichVu_ldv_id",
                table: "DichVu");

            migrationBuilder.DropIndex(
                name: "IX_DichVu_ldv_id",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "dv_quanhuyen",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "dv_tinhthanh",
                table: "DichVu");

            migrationBuilder.AddColumn<int>(
                name: "loaiDichVuldv_id",
                table: "DichVu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_loaiDichVuldv_id",
                table: "DichVu",
                column: "loaiDichVuldv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DichVu_LoaiDichVu_loaiDichVuldv_id",
                table: "DichVu",
                column: "loaiDichVuldv_id",
                principalTable: "LoaiDichVu",
                principalColumn: "ldv_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
