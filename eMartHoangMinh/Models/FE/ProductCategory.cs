using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eMartHoangMinh.Models.FE
{
    [Table("tb_ProductCategory")]
    public class ProductCategory : CommonAbtract
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SeoName { get; set; }
        public string Icon { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int Position { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}