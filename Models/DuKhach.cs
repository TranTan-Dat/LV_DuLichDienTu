using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("DuKhach")]
    public class DuKhach{
        
        [Key]
        [Required]
        [DisplayName("Mã du khách")]
        public int dk_id{get;set;}

        [DisplayName("tài khoản")]
        public string dk_taikhoan{get;set;}

        [DisplayName("Họ tên")]
        public string dk_hoten{get;set;}

        [DisplayName("CMND/CCCD")]
        public string dk_cmnd{get;set;}

        [DisplayName("Điện thoại")]
        public string dk_dienthoai{get;set;}

        [DisplayName("Địa chỉ")]
        public string dk_diachi{get;set;}

        [DisplayName("Email")]
        public string dk_email{get;set;}

        [DisplayName("Điểm thành viên")]
        public int dk_diemthanhvien{get;set;}

        [ForeignKey("bvdd_id")]
        public int bvdd_id {get;set;}
        public ICollection<BaiViet_DiaDiem> BaiViet_DiaDiems {get; set;}


        [ForeignKey("hd_id")]
        public int hd_id {get;set;}
        public ICollection<HopDong> HopDongs {get; set;}
        
    }
}