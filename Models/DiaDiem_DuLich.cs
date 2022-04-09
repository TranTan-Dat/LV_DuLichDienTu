using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("DiaDiem_DuLich")]
    public class DiaDiem_DuLich{
        [Key]
        [Required]
        [DisplayName("Mã địa điểm")]
        public int dddl_id{get;set;}
        [DisplayName("Tên địa điểm")]
        public string dddl_ten {get;set;}
        
        [DisplayName("Mô tả về địa điểm")]
        public string dddl_mota {get;set;}


        [ForeignKey("Hinh_DiaDiemDuLich")]
        public int hinh_id {get; set;}
        public ICollection<Hinh_DiaDiemDuLich> hinh_DiaDiemDuLiches {get; set;}

        [ForeignKey("BaiViet_DiaDiem")]
        public int bvdd_id {get; set;}
        public ICollection<BaiViet_DiaDiem> baiViet_DiaDiems {get; set;}
    }
}