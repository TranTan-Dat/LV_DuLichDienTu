using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;

    public class acompec_lvdatContext : DbContext
    {
        public acompec_lvdatContext (DbContextOptions<acompec_lvdatContext> options)
            : base(options)
        {
        }

        public DbSet<LV_DuLichDienTu.Models.BaiViet_DiaDiem> BaiViet_DiaDiem { get; set; }

        public DbSet<LV_DuLichDienTu.Models.CamKetDichVu> CamKetDichVu { get; set; }

        public DbSet<LV_DuLichDienTu.Models.DiaDiem_DuLich> DiaDiem_DuLich { get; set; }

        public DbSet<LV_DuLichDienTu.Models.DichVu> DichVu { get; set; }

        public DbSet<LV_DuLichDienTu.Models.DuKhach> DuKhach { get; set; }


        public DbSet<LV_DuLichDienTu.Models.HopDong> HopDong { get; set; }

        public DbSet<LV_DuLichDienTu.Models.LoaiDichVu> LoaiDichVu { get; set; }

        public DbSet<LV_DuLichDienTu.Models.NhaCungCap> NhaCungCap { get; set; }

        public DbSet<LV_DuLichDienTu.Models.NhanVien> NhanVien { get; set; }
    }
