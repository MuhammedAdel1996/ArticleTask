using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleTask.Models
{
    public class Comments
    {
        public int id { set; get; }
        [Required]
        public string comment { set; get; }
        public int articaleid { set; get; }
        public virtual Article Article{set;get;}
    }
}