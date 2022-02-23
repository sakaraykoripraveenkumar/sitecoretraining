using CTS.Project.CTS.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTS.Project.CTS.Controllers
{
    public class FeaturedArticleController : Controller
    {
        // GET: FeaturedArticle
        public ActionResult GetFeaturedArticle()
        {
            var datasourceItem = RenderingContext.Current.Rendering.Item;
            Article article = new Article
            {
                Title = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(datasourceItem, "Title")),
                Brief = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(datasourceItem, "Brief")),
                ArticleUrl = LinkManager.GetItemUrl(datasourceItem)
            };
            return View("/Views/Cts/Common/FeaturedArticle.cshtml",article);
        }
    }
}