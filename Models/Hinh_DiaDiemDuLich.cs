using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LV_DuLichDienTu.Models
{
    [Table ("Hinh_DiaDiemDuLich")]
    public class Hinh_DiaDiemDuLich
    {
        [Key]
        [Required]
        [DisplayName("Mã hình địa điểm")]
        public int hinh_id {get;set;}
        [DisplayName("Đường dẫn ảnh")]
        public string hinh_duongdan {get; set;}

        [ForeignKey("dddl_id")]
        [Required]
        public int dddl_id {get; set;}
        [ForeignKey("dddl_id")]
        public virtual DiaDiem_DuLich DiaDiem_DuLich{get;set;}
        
    }
}