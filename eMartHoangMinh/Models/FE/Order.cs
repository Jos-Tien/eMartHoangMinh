using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace eMartHoangMinh.Models.FE
{
    [Table("tb_Order")]
    public class Order : CommonAbtract
    {
        public Order()
        {
            this.Details = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }

        public ICollection<OrderDetail> Details { get; set; }

    }
}