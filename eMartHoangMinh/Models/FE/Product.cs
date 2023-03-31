using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMartHoangMinh.Models.FE
{
    [Table("tb_Product")]
    public class Product : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public int ProductCategoryId { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public bool IsSale { get; set; }
        public bool IsHome {get; set; }
        public bool IsHot { get; set; }
        public bool IsFeture { get; set; }
        public int Quantity { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}