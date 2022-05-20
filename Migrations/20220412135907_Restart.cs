using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LV_DuLichDienTu.Migrations
{
    public partial class Restart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaDiem_DuLich",
                columns: table => new
                {
                    dddl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dddl_ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dddl_mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hinh_id = table.Column<int>(type: "int", nullable: false),
                    bvdd_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiem_DuLich", x => x.dddl_id);
                });

            migrationBuilder.CreateTable(
                name: "DuKhach",
                columns: table => new
                {
                    dk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dk_taikhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dk_hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dk_cmnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dk_dienthoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dk_diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dk_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dk_diemthanhvien = table.Column<int>(type: "int", nullable: false),
                    bvdd_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuKhach", x => x.dk_id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDichVu",
                columns: table => new
                {
                    ldv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ldv_ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ldv_mota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDichVu", x => x.ldv_id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    ncc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ncc_taikhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ncc_matkhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ncc_ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ncc_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ncc_dienthoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ncc_diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dv_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.ncc_id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    nv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nv_taikhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nv_matKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nv_hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nv_cmnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nv_dienthoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nv_diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nv_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bvdd_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.nv_id);
                });

            // migrationBuilder.CreateTable(
            //     name: "Hinh_DiaDiemDuLich",
            //     columns: table => new
            //     {
            //         hinh_id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         hinh_duongdan = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         dddl_id = table.Column<int>(type: "int", nullable: false),
            //         DiaDiem_DuLichdddl_id = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Hinh_DiaDiemDuLich", x => x.hinh_id);
            //         table.ForeignKey(
            //             name: "FK_Hinh_DiaDiemDuLich_DiaDiem_DuLich_DiaDiem_DuLichdddl_id",
            //             column: x => x.DiaDiem_DuLichdddl_id,
            //             principalTable: "DiaDiem_DuLich",
            //             principalColumn: "dddl_id",
            //             onDelete: ReferentialAction.Restrict);
            //     });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    dv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dv_ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dv_dienthoai_hotro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dv_mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bvdd_id = table.Column<int>(type: "int", nullable: false),
                    ncc_id = table.Column<int>(type: "int", nullable: false),
                    nhaCungCapncc_id = table.Column<int>(type: "int", nullable: true),
                    ldv_id = table.Column<int>(type: "int", nullable: false),
                    loaiDichVuldv_id = table.Column<int>(type: "int", nullable: true),
                    hd_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.dv_id);
                    table.ForeignKey(
                        name: "FK_DichVu_LoaiDichVu_loaiDichVuldv_id",
                        column: x => x.loaiDichVuldv_id,
                        principalTable: "LoaiDichVu",
                        principalColumn: "ldv_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DichVu_NhaCungCap_nhaCungCapncc_id",
                        column: x => x.nhaCungCapncc_id,
                        principalTable: "NhaCungCap",
                        principalColumn: "ncc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet_DiaDiem",
                columns: table => new
                {
                    bvdd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bvdd_tieude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bvdd_noidung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bvdd_tinhtrang = table.Column<bool>(type: "bit", nullable: false),
                    dddl_id = table.Column<int>(type: "int", nullable: false),
                    DiaDiem_DuLichdddl_id = table.Column<int>(type: "int", nullable: true),
                    nv_id = table.Column<int>(type: "int", nullable: false),
                    NhanViennv_id = table.Column<int>(type: "int", nullable: true),
                    dk_id = table.Column<int>(type: "int", nullable: false),
                    DuKhachdk_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet_DiaDiem", x => x.bvdd_id);
                    table.ForeignKey(
                        name: "FK_BaiViet_DiaDiem_DiaDiem_DuLich_DiaDiem_DuLichdddl_id",
                        column: x => x.DiaDiem_DuLichdddl_id,
                        principalTable: "DiaDiem_DuLich",
                        principalColumn: "dddl_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaiViet_DiaDiem_DuKhach_DuKhachdk_id",
                        column: x => x.DuKhachdk_id,
                        principalTable: "DuKhach",
                        principalColumn: "dk_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaiViet_DiaDiem_NhanVien_NhanViennv_id",
                        column: x => x.NhanViennv_id,
                        principalTable: "NhanVien",
                        principalColumn: "nv_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CamKetDichVu",
                columns: table => new
                {
                    ckdv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ckdv_noidung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ckdv_boithuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dv_id = table.Column<int>(type: "int", nullable: false),
                    dichVudv_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamKetDichVu", x => x.ckdv_id);
                    table.ForeignKey(
                        name: "FK_CamKetDichVu_DichVu_dichVudv_id",
                        column: x => x.dichVudv_id,
                        principalTable: "DichVu",
                        principalColumn: "dv_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    hd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hd_ngaybatdau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hd_ngayketthuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hd_chiphi = table.Column<double>(type: "float", nullable: false),
                    hd_danhgiachatluong = table.Column<double>(type: "float", nullable: false),
                    hd_phanhoi = table.Column<double>(type: "float", nullable: false),
                    dk_id = table.Column<int>(type: "int", nullable: false),
                    duKhachdk_id = table.Column<int>(type: "int", nullable: true),
                    DichVudv_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.hd_id);
                    table.ForeignKey(
                        name: "FK_HopDong_DichVu_DichVudv_id",
                        column: x => x.DichVudv_id,
                        principalTable: "DichVu",
                        principalColumn: "dv_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_DuKhach_duKhachdk_id",
                        column: x => x.duKhachdk_id,
                        principalTable: "DuKhach",
                        principalColumn: "dk_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_DiaDiem_DuLichdddl_id",
                table: "BaiViet_DiaDiem",
                column: "DiaDiem_DuLichdddl_id");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_DuKhachdk_id",
                table: "BaiViet_DiaDiem",
                column: "DuKhachdk_id");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_DiaDiem_NhanViennv_id",
                table: "BaiViet_DiaDiem",
                column: "NhanViennv_id");

            migrationBuilder.CreateIndex(
                name: "IX_CamKetDichVu_dichVudv_id",
                table: "CamKetDichVu",
                column: "dichVudv_id");

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_loaiDichVuldv_id",
                table: "DichVu",
                column: "loaiDichVuldv_id");

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_nhaCungCapncc_id",
                table: "DichVu",
                column: "nhaCungCapncc_id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Hinh_DiaDiemDuLich_DiaDiem_DuLichdddl_id",
            //     table: "Hinh_DiaDiemDuLich",
            //     column: "DiaDiem_DuLichdddl_id");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_DichVudv_id",
                table: "HopDong",
                column: "DichVudv_id");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_duKhachdk_id",
                table: "HopDong",
                column: "duKhachdk_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet_DiaDiem");

            migrationBuilder.DropTable(
                name: "CamKetDichVu");

            // migrationBuilder.DropTable(
            //     name: "Hinh_DiaDiemDuLich");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "DiaDiem_DuLich");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "DuKhach");

            migrationBuilder.DropTable(
                name: "LoaiDichVu");

            migrationBuilder.DropTable(
                name: "NhaCungCap");
        }
    }
}
