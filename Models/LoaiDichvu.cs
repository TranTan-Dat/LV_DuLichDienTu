using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("LoaiDichVu")]
    public class LoaiDichVu{
        
        [Key]
        [Required]
        [DisplayName("Mã loại dịch vụ")]
        public int ldv_id{get;set;}

        [DisplayName("Tên")]
        public string ldv_ten{get;set;}

        [DisplayName("Mô tử")]
        public string ldv_mota{get;set;}


        public ICollection<DichVu> dichvus {get;set;}
    }
}