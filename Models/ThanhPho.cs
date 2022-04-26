// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace LV_DuLichDienTu.Models
// {
//     [Table("ThanhPho")]
//     public class ThanhPho
//     {
//         [Key]
//         [Required]
//         [DisplayName("Mã thành phố")]
//         public int tp_id {get;set;}
//         [Required]
//         [DisplayName("Tên thành phố")]
//         public string tp_ten {get;set;}

//         [ForeignKey("dddl_id")]
//         public int dddl_id {get; set;}
//         public ICollection<DiaDiem_DuLich> diaDiem_DuLiches {get; set;}
//     }
// }