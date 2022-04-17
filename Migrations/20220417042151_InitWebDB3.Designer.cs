﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LV_DuLichDienTu.Migrations
{
    [DbContext(typeof(acompec_lvdatContext))]
    [Migration("20220417042151_InitWebDB3")]
    partial class InitWebDB3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LV_DuLichDienTu.Models.BaiViet_DiaDiem", b =>
                {
                    b.Property<int>("bvdd_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiaDiem_DuLichdddl_id")
                        .HasColumnType("int");

                    b.Property<int?>("DuKhachdk_id")
                        .HasColumnType("int");

                    b.Property<int?>("NhanViennv_id")
                        .HasColumnType("int");

                    b.Property<string>("bvdd_noidung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bvdd_tieude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("bvdd_tinhtrang")
                        .HasColumnType("bit");

                    b.Property<int>("dddl_id")
                        .HasColumnType("int");

                    b.Property<int>("dk_id")
                        .HasColumnType("int");

                    b.Property<int>("nv_id")
                        .HasColumnType("int");

                    b.HasKey("bvdd_id");

                    b.HasIndex("DiaDiem_DuLichdddl_id");

                    b.HasIndex("DuKhachdk_id");

                    b.HasIndex("NhanViennv_id");

                    b.ToTable("BaiViet_DiaDiem");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.CamKetDichVu", b =>
                {
                    b.Property<int>("ckdv_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ckdv_boithuong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ckdv_noidung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("dichVudv_id")
                        .HasColumnType("int");

                    b.Property<int>("dv_id")
                        .HasColumnType("int");

                    b.HasKey("ckdv_id");

                    b.HasIndex("dichVudv_id");

                    b.ToTable("CamKetDichVu");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DiaDiem_DuLich", b =>
                {
                    b.Property<int>("dddl_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bvdd_id")
                        .HasColumnType("int");

                    b.Property<string>("dddl_mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dddl_ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dddl_tinhthanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hinh_id")
                        .HasColumnType("int");

                    b.HasKey("dddl_id");

                    b.ToTable("DiaDiem_DuLich");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DichVu", b =>
                {
                    b.Property<int>("dv_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bvdd_id")
                        .HasColumnType("int");

                    b.Property<string>("dv_dienthoai_hotro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dv_mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dv_ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hd_id")
                        .HasColumnType("int");

                    b.Property<int>("ldv_id")
                        .HasColumnType("int");

                    b.Property<int?>("loaiDichVuldv_id")
                        .HasColumnType("int");

                    b.Property<int>("ncc_id")
                        .HasColumnType("int");

                    b.Property<int?>("nhaCungCapncc_id")
                        .HasColumnType("int");

                    b.HasKey("dv_id");

                    b.HasIndex("loaiDichVuldv_id");

                    b.HasIndex("nhaCungCapncc_id");

                    b.ToTable("DichVu");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DuKhach", b =>
                {
                    b.Property<int>("dk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bvdd_id")
                        .HasColumnType("int");

                    b.Property<string>("dk_cmnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dk_diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dk_diemthanhvien")
                        .HasColumnType("int");

                    b.Property<string>("dk_dienthoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dk_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dk_hoten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dk_taikhoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("hd_id")
                        .HasColumnType("int");

                    b.HasKey("dk_id");

                    b.ToTable("DuKhach");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.Hinh_DiaDiemDuLich", b =>
                {
                    b.Property<int>("hinh_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("dddl_id")
                        .HasColumnType("int");

                    b.Property<string>("hinh_duongdan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hinh_id");

                    b.HasIndex("dddl_id");

                    b.ToTable("Hinh_DiaDiemDuLich");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.HopDong", b =>
                {
                    b.Property<int>("hd_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("dichVudv_id")
                        .HasColumnType("int");

                    b.Property<int>("dk_id")
                        .HasColumnType("int");

                    b.Property<int?>("duKhachdk_id")
                        .HasColumnType("int");

                    b.Property<int>("dv_id")
                        .HasColumnType("int");

                    b.Property<double>("hd_chiphi")
                        .HasColumnType("float");

                    b.Property<double>("hd_danhgiachatluong")
                        .HasColumnType("float");

                    b.Property<DateTime>("hd_ngaybatdau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("hd_ngayketthuc")
                        .HasColumnType("datetime2");

                    b.Property<double>("hd_phanhoi")
                        .HasColumnType("float");

                    b.HasKey("hd_id");

                    b.HasIndex("dichVudv_id");

                    b.HasIndex("duKhachdk_id");

                    b.ToTable("HopDong");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.LoaiDichVu", b =>
                {
                    b.Property<int>("ldv_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ldv_mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ldv_ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ldv_id");

                    b.ToTable("LoaiDichVu");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.NhaCungCap", b =>
                {
                    b.Property<int>("ncc_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("dv_id")
                        .HasColumnType("int");

                    b.Property<string>("ncc_diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ncc_dienthoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ncc_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ncc_matkhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ncc_taikhoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ncc_ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ncc_id");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.NhanVien", b =>
                {
                    b.Property<int>("nv_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bvdd_id")
                        .HasColumnType("int");

                    b.Property<string>("nv_cmnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nv_diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nv_dienthoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nv_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nv_hoten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nv_matKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nv_taikhoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nv_id");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.BaiViet_DiaDiem", b =>
                {
                    b.HasOne("LV_DuLichDienTu.Models.DiaDiem_DuLich", "DiaDiem_DuLich")
                        .WithMany("baiViet_DiaDiems")
                        .HasForeignKey("DiaDiem_DuLichdddl_id");

                    b.HasOne("LV_DuLichDienTu.Models.DuKhach", "DuKhach")
                        .WithMany("BaiViet_DiaDiems")
                        .HasForeignKey("DuKhachdk_id");

                    b.HasOne("LV_DuLichDienTu.Models.NhanVien", "NhanVien")
                        .WithMany("baiViet_DiaDiems")
                        .HasForeignKey("NhanViennv_id");

                    b.Navigation("DiaDiem_DuLich");

                    b.Navigation("DuKhach");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.CamKetDichVu", b =>
                {
                    b.HasOne("LV_DuLichDienTu.Models.DichVu", "dichVu")
                        .WithMany("camKetDichVus")
                        .HasForeignKey("dichVudv_id");

                    b.Navigation("dichVu");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DichVu", b =>
                {
                    b.HasOne("LV_DuLichDienTu.Models.LoaiDichVu", "loaiDichVu")
                        .WithMany("dichvus")
                        .HasForeignKey("loaiDichVuldv_id");

                    b.HasOne("LV_DuLichDienTu.Models.NhaCungCap", "nhaCungCap")
                        .WithMany("dichVus")
                        .HasForeignKey("nhaCungCapncc_id");

                    b.Navigation("loaiDichVu");

                    b.Navigation("nhaCungCap");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.Hinh_DiaDiemDuLich", b =>
                {
                    b.HasOne("LV_DuLichDienTu.Models.DiaDiem_DuLich", "DiaDiem_DuLich")
                        .WithMany("hinh_DiaDiemDuLiches")
                        .HasForeignKey("dddl_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiaDiem_DuLich");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.HopDong", b =>
                {
                    b.HasOne("LV_DuLichDienTu.Models.DichVu", "dichVu")
                        .WithMany("hopDongs")
                        .HasForeignKey("dichVudv_id");

                    b.HasOne("LV_DuLichDienTu.Models.DuKhach", "duKhach")
                        .WithMany("HopDongs")
                        .HasForeignKey("duKhachdk_id");

                    b.Navigation("dichVu");

                    b.Navigation("duKhach");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DiaDiem_DuLich", b =>
                {
                    b.Navigation("baiViet_DiaDiems");

                    b.Navigation("hinh_DiaDiemDuLiches");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DichVu", b =>
                {
                    b.Navigation("camKetDichVus");

                    b.Navigation("hopDongs");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.DuKhach", b =>
                {
                    b.Navigation("BaiViet_DiaDiems");

                    b.Navigation("HopDongs");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.LoaiDichVu", b =>
                {
                    b.Navigation("dichvus");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.NhaCungCap", b =>
                {
                    b.Navigation("dichVus");
                });

            modelBuilder.Entity("LV_DuLichDienTu.Models.NhanVien", b =>
                {
                    b.Navigation("baiViet_DiaDiems");
                });
#pragma warning restore 612, 618
        }
    }
}
