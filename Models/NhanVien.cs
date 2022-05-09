using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("NhanVien")]
    public class NhanVien
    {
        [Key]
        [Required]
        [DisplayName("Mã nhân viên")]
        public int nv_id {get;set;}

        [DisplayName("Tài khoản")]
        public string nv_taikhoan {get;set;}

        [DisplayName("Mật Khẩu")]
        public string nv_matKhau {get;set;}

        [DisplayName("Họ tên")]
        public string nv_hoten {get;set;}

        [DisplayName("CMND")]
        public string nv_cmnd {get;set;}

        [DisplayName("SĐT")]
        public string nv_dienthoai {get;set;}

        [DisplayName("Địa chỉ")]
        public string nv_diachi {get;set;}

        [DisplayName("email")]
        public string nv_email {get;set;}


        [ForeignKey("BaiViet_DiaDiem")]
        public int bvdd_id{get;set;}
        public ICollection<BaiViet_DiaDiem> baiViet_DiaDiems {get; set;}
    }
}