using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("NhaCungCap")]
    public class NhaCungCap{
        
        [Key]
        [Required]
        [DisplayName("Mã nhà cung cấp")]
        public int ncc_id{get;set;}

        [DisplayName("Tài Khoản nhà cung cấp")]
        public string ncc_taikhoan{get;set;}

        [DisplayName("Mật khẩu")]
        public string ncc_matkhau{get;set;}

        [DisplayName("Tên")]
        public string ncc_ten{get;set;}

        [DisplayName("Email")]
        public string ncc_email{get;set;}

        [DisplayName("Số điện thoại")]
        public string ncc_dienthoai{get;set;}

        [DisplayName("Địa chỉ")]
        public string ncc_diachi{get;set;}
        
        [ForeignKey("DichVu")]
        [DisplayName("Mã dịch vụ")]
        public int dv_id  {get;set;}
        public ICollection<DichVu> dichVus {get;set;}
    }
}