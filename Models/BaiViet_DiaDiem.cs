using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("BaiViet_DiaDiem")]
    public class BaiViet_DiaDiem{
        [Key]
        [Required]
        [DisplayName("Mã bài viết")]
        public int bvdd_id{get;set;}

        [DisplayName("Tiêu đề bài viết")]
        public string bvdd_tieude{get;set;}

        [DisplayName("Nội dung bài viết")]
        public string bvdd_noidung{get;set;}

        [DisplayName("Tình trạng")]
        public Boolean bvdd_tinhtrang{get;set;}


        [ForeignKey("dddl_id")]
        public int dddl_id {get;set;}
        [ForeignKey("dddl_id")]
        public virtual DiaDiem_DuLich DiaDiem_DuLich {get;set;}
        
        [ForeignKey("nv_id")]
        public int nv_id {get;set;}
        [ForeignKey("nv_id")]
        //virtual giúp cho chuyển id sang tên

        public virtual NhanVien NhanVien {get;set;}
        

        [ForeignKey("dk_id")]
        public int dk_id {get;set;}
        public DuKhach DuKhach {get;set;}
    }
}