using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;

namespace LV_DuLichDienTu.Models
{
    public class acompec_lvdatContext : DbContext
    {
        public acompec_lvdatContext(DbContextOptions<acompec_lvdatContext> options): base(options)
        {

        }

        public DbSet<BaiViet_DiaDiem> baiViet_DiaDiems {get;set;}
        public DbSet<CamKetDichVu> camKetDichVus {get;set;}
        public DbSet<DiaDiem_DuLich> diaDiem_DuLiches {get;set;}
        public DbSet<DichVu> dichVus {get;set;}
        public DbSet<DuKhach> duKhaches {get;set;}
        public DbSet<Hinh_DiaDiemDuLich> hinh_DiaDiemDuLiches {get;set;}
        public DbSet<HopDong> hopDongs {get;set;}
        public DbSet<LoaiDichVu> loaiDichVus {get;set;}
        public DbSet<NhaCungCap> nhaCungCaps {get;set;}
        public DbSet<NhanVien> nhanViens {get;set;}

    }
}