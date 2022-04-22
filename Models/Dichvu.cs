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

        [DisplayName("Mô tả")]
        public string dv_mota{get;set;}

        [ForeignKey("ckdv_id")]
        public int ckdv_id {get;set;}
        public ICollection<CamKetDichVu> camKetDichVus {get;set;}
        

        [ForeignKey("ncc_id")]
        public int ncc_id {get;set;}
        [ForeignKey("ncc_id")]
        public virtual NhaCungCap nhaCungCap{get;set;}

        [ForeignKey("ldv_id")]
        public int ldv_id {get;set;}
        public LoaiDichVu loaiDichVu {get;set;}

        [ForeignKey("hd_id")]
        public int hd_id {get;set;}
        public ICollection<HopDong> hopDongs {get;set;}
    }
}