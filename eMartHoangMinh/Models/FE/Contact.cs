using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eMartHoangMinh.Models.FE
{
    [Table("tb_Contact")]
    public class Contact : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Tên không được dài quá 150 ký tự")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email không được để trống")]
        [StringLength(150)]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}