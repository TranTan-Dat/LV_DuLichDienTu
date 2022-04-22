using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_DiaDiem_DiaDiem_DuLich_DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_DiaDiem_NhanVien_NhanViennv_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropIndex(
                name: "IX_BaiViet_DiaDiem_DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropIndex(
                name: "IX_BaiViet_DiaDiem_NhanViennv_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropColumn(
                name: "DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropColumn(
                name: "NhanViennv_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.RenameColumn(
                name: "bvdd_id",
                table: "DichVu",
                newName: "ckdv_id");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_dddl_id",
                table: "BaiViet_DiaDiem",
                column: "dddl_id");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_nv_id",
                table: "BaiViet_DiaDiem",
                column: "nv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_DiaDiem_DiaDiem_DuLich_dddl_id",
                table: "BaiViet_DiaDiem",
                column: "dddl_id",
                principalTable: "DiaDiem_DuLich",
                principalColumn: "dddl_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_DiaDiem_NhanVien_nv_id",
                table: "BaiViet_DiaDiem",
                column: "nv_id",
                principalTable: "NhanVien",
                principalColumn: "nv_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_DiaDiem_DiaDiem_DuLich_dddl_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_DiaDiem_NhanVien_nv_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropIndex(
                name: "IX_BaiViet_DiaDiem_dddl_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.DropIndex(
                name: "IX_BaiViet_DiaDiem_nv_id",
                table: "BaiViet_DiaDiem");

            migrationBuilder.RenameColumn(
                name: "ckdv_id",
                table: "DichVu",
                newName: "bvdd_id");

            migrationBuilder.AddColumn<int>(
                name: "DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanViennv_id",
                table: "BaiViet_DiaDiem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem",
                column: "DiaDiem_DuLichdddl_id");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_NhanViennv_id",
                table: "BaiViet_DiaDiem",
                column: "NhanViennv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_DiaDiem_DiaDiem_DuLich_DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem",
                column: "DiaDiem_DuLichdddl_id",
                principalTable: "DiaDiem_DuLich",
                principalColumn: "dddl_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_DiaDiem_NhanVien_NhanViennv_id",
                table: "BaiViet_DiaDiem",
                column: "NhanViennv_id",
                principalTable: "NhanVien",
                principalColumn: "nv_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
