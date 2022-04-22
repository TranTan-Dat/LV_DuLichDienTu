using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("CamKetDichVu")]
    public class CamKetDichVu{
        
        [Key]
        [Required]
        [DisplayName("Mã cam kết")]
        public int ckdv_id{get;set;}

        [DisplayName("Nội dung cam kết")]
        public string ckdv_noidung{get;set;}

        [DisplayName("Bồi thường")]
        public string ckdv_boithuong{get;set;}
        
        [ForeignKey("dv_id")]
        public int dv_id  {get;set;}
        [ForeignKey("dv_id")]
        public virtual DichVu dichVu {get;set;}
    }
}