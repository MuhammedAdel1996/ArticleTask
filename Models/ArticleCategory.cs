using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleTask.Models
{
    public class ArticleCategory
    {
        public int id { set; get; }
        [Required]
        public string name { set; get; }
        public virtual List<Article> Articles { set; get; }
    }
}