using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eMartHoangMinh.Models.FE
{
    [Table("tb_SystemSetting")]
    public class SystemSetting : CommonAbtract
    {
        [Key]
        [StringLength(25)]
        public string SetKey { get; set; }
        [StringLength(4000)]
        public string Value { get; set; }
        public string Description { get; set; }
    }
}