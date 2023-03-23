using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eMartHoangMinh.Models.FE
{
    [Table("tb_Category")]
    public class Category : CommonAbtract
    {
        public Category()
        {
            this.News = new HashSet<News>();
            this.Posts = new HashSet<Post>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field required")]
        [StringLength(1000,ErrorMessage ="Description max length 1000 char")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field required")]
        [StringLength(100, ErrorMessage = "Description max length 100 char")]
        public string SeoName { get; set; }
        [StringLength(1000, ErrorMessage = "Description max length 1000 char")]
        public string SeoDescription { get; set; }

        [Required(ErrorMessage = "Field required")]
        [StringLength(100, ErrorMessage = "Description max length 1000 char")]
        public string SeoKeywords { get; set; }
        public int Position { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}