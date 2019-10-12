using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleTask.Models
{
    public class Article
    {
        public int id { get; set; }
        [Required]
        public string title { set; get; }
        [Required]
        public string body { set; get; }
        public int categoryid { set; get; }
        public virtual ArticleCategory ArticleCategory { set; get; }
        public virtual List<Comments> Comments { set; get; }
    }
}