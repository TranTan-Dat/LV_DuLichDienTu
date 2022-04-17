using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DichVu_DichVudv_id",
                table: "HopDong");

            migrationBuilder.RenameColumn(
                name: "DichVudv_id",
                table: "HopDong",
                newName: "dichVudv_id");

            migrationBuilder.RenameIndex(
                name: "IX_HopDong_DichVudv_id",
                table: "HopDong",
                newName: "IX_HopDong_dichVudv_id");

            migrationBuilder.AddColumn<int>(
                name: "dv_id",
                table: "HopDong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DichVu_dichVudv_id",
                table: "HopDong",
                column: "dichVudv_id",
                principalTable: "DichVu",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DichVu_dichVudv_id",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "dv_id",
                table: "HopDong");

            migrationBuilder.RenameColumn(
                name: "dichVudv_id",
                table: "HopDong",
                newName: "DichVudv_id");

            migrationBuilder.RenameIndex(
                name: "IX_HopDong_dichVudv_id",
                table: "HopDong",
                newName: "IX_HopDong_DichVudv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DichVu_DichVudv_id",
                table: "HopDong",
                column: "DichVudv_id",
                principalTable: "DichVu",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
