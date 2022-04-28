using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DichVu_dichVudv_id",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DuKhach_duKhachdk_id",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_dichVudv_id",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_duKhachdk_id",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "dichVudv_id",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "duKhachdk_id",
                table: "HopDong");

            migrationBuilder.AddColumn<string>(
                name: "dddl_quanhuyen",
                table: "DiaDiem_DuLich",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_dk_id",
                table: "HopDong",
                column: "dk_id");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_dv_id",
                table: "HopDong",
                column: "dv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DichVu_dv_id",
                table: "HopDong",
                column: "dv_id",
                principalTable: "DichVu",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DuKhach_dk_id",
                table: "HopDong",
                column: "dk_id",
                principalTable: "DuKhach",
                principalColumn: "dk_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DichVu_dv_id",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DuKhach_dk_id",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_dk_id",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_dv_id",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "dddl_quanhuyen",
                table: "DiaDiem_DuLich");

            migrationBuilder.AddColumn<int>(
                name: "dichVudv_id",
                table: "HopDong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "duKhachdk_id",
                table: "HopDong",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_dichVudv_id",
                table: "HopDong",
                column: "dichVudv_id");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_duKhachdk_id",
                table: "HopDong",
                column: "duKhachdk_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DichVu_dichVudv_id",
                table: "HopDong",
                column: "dichVudv_id",
                principalTable: "DichVu",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DuKhach_duKhachdk_id",
                table: "HopDong",
                column: "duKhachdk_id",
                principalTable: "DuKhach",
                principalColumn: "dk_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
