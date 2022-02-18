using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTS.Project.CTS.Models
{
    public class Article
    {

        public HtmlString Title { set; get; }
        public HtmlString Brief { set; get; }
        public HtmlString DetailBlog { set; get; }

        public HtmlString Author { set; get; }

        public String ArticleUrl { set; get; }
        
    }
}