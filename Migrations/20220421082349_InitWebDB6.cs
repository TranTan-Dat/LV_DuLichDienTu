using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class InitWebDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CamKetDichVu_DichVu_dichVudv_id",
                table: "CamKetDichVu");

            migrationBuilder.DropIndex(
                name: "IX_CamKetDichVu_dichVudv_id",
                table: "CamKetDichVu");

            migrationBuilder.DropColumn(
                name: "dichVudv_id",
                table: "CamKetDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_CamKetDichVu_dv_id",
                table: "CamKetDichVu",
                column: "dv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CamKetDichVu_DichVu_dv_id",
                table: "CamKetDichVu",
                column: "dv_id",
                principalTable: "DichVu",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CamKetDichVu_DichVu_dv_id",
                table: "CamKetDichVu");

            migrationBuilder.DropIndex(
                name: "IX_CamKetDichVu_dv_id",
                table: "CamKetDichVu");

            migrationBuilder.AddColumn<int>(
                name: "dichVudv_id",
                table: "CamKetDichVu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CamKetDichVu_dichVudv_id",
                table: "CamKetDichVu",
                column: "dichVudv_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CamKetDichVu_DichVu_dichVudv_id",
                table: "CamKetDichVu",
                column: "dichVudv_id",
                principalTable: "DichVu",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
