using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("DichVu")]
    public class DichVu{
        
        [Key]
        [Required]
        [DisplayName("Mã dịch vụ")]
        public int dv_id{get;set;}

        [DisplayName("Tên")]
        public string dv_ten{get;set;}

        [DisplayName("Điện thoại hỗ trợ")]
        public string dv_dienthoai_hotro{get;set;}
        // ảnh cho dịch vụ
        [DisplayName("Đường dẫn ảnh")]
        public string dv_hinh_duongdan {get; set;}
        // Tiêu đề
        [DisplayName("Mô tả ngắn")]
        public string dv_tieude {get; set;}

        [DisplayName("Tỉnh thành")]
        
        public string dv_tinhthanh {get;set;}
        [DisplayName("Quận huyện")]
        public string dv_quanhuyen {get;set;}

        [DisplayName("Mô tả")]
        public string dv_mota{get;set;}

        [DisplayName("Giá trung bình")]
        public int dv_tb_gia{get;set;}

        [DisplayName("Trung bình chất lượng")]
        public double dv_trungbinhchatluong{get;set;}

        [ForeignKey("ckdv_id")]
        public int ckdv_id {get;set;}
        public ICollection<CamKetDichVu> camKetDichVus {get;set;}
        
    

        [ForeignKey("ncc_id")]
        public int ncc_id {get;set;}
        [ForeignKey("ncc_id")]
        public virtual NhaCungCap nhaCungCap{get;set;}

        [ForeignKey("ldv_id")]
        public int ldv_id {get;set;}
        [ForeignKey("ldv_id")]
        public virtual LoaiDichVu loaiDichVu {get;set;}

        [ForeignKey("hd_id")]
        public int hd_id {get;set;}
        public ICollection<HopDong> hopDongs {get;set;}
    }
}