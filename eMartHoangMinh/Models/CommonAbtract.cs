using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMartHoangMinh.Models
{
    public class CommonAbtract
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}