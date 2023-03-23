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
        public string Name { get; set; }
        public string Description { get; set; }
        public string SeoName { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public int Position { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}