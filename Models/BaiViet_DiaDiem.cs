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

        [DisplayName("Mã bài viết")]
        public string bvdd_tieude{get;set;}

        [DisplayName("Mã bài viết")]
        public string bvdd_noidung{get;set;}

        [DisplayName("Mã bài viết")]
        public Boolean bvdd_tinhtrang{get;set;}
    }
}