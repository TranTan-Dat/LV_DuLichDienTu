using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// chưa hiểu hết mấy cái đó nhưng từ từ tìm hiểu sau
namespace LV_DuLichDienTu.Models
{
    [Table ("HopDong")]
    public class HopDong{
        
        [Key]
        [Required]
        [DisplayName("Mã hợp đồng")]
        public int hd_id{get;set;}

        [DisplayName("Ngày bắt đầu")]
        public DateTime hd_ngaybatdau{get;set;}

        [DisplayName("Ngày kết thúc")]
        public DateTime hd_ngayketthuc{get;set;}

        [DisplayName("Tổng chi phí")]
        public Double hd_chiphi{get;set;}

        [DisplayName("Đánh giá chất lượng")]
        public Double hd_danhgiachatluong{get;set;}

        [DisplayName("Phản hồi")]
        public Double hd_phanhoi{get;set;}

        [ForeignKey("DuKhach")]
        public int dk_id {get;set;}
        public DuKhach duKhach {get; set;}

        
    }
}