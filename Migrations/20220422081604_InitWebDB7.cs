using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DichVu_NhaCungCap_nhaCungCapncc_id",
                table: "DichVu");

            migrationBuilder.DropIndex(
                name: "IX_DichVu_nhaCungCapncc_id",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "nhaCungCapncc_id",
                table: "DichVu");

            migrationBuilder.AlterColumn<string>(
                name: "hd_phanhoi",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_ncc_id",
                table: "DichVu",
                column: "ncc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DichVu_NhaCungCap_ncc_id",
                table: "DichVu",
                column: "ncc_id",
                principalTable: "NhaCungCap",
                principalColumn: "ncc_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DichVu_NhaCungCap_ncc_id",
                table: "DichVu");

            migrationBuilder.DropIndex(
                name: "IX_DichVu_ncc_id",
                table: "DichVu");

            migrationBuilder.AlterColumn<double>(
                name: "hd_phanhoi",
                table: "HopDong",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nhaCungCapncc_id",
                table: "DichVu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_nhaCungCapncc_id",
                table: "DichVu",
                column: "nhaCungCapncc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DichVu_NhaCungCap_nhaCungCapncc_id",
                table: "DichVu",
                column: "nhaCungCapncc_id",
                principalTable: "NhaCungCap",
                principalColumn: "ncc_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
