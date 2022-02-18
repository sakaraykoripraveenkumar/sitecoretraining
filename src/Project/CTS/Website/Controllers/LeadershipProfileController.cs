using CTS.Project.CTS.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTS.Project.CTS.Controllers
{
    public class LeadershipProfileController : Controller
    {
        // GET: LeadershipProfile
        public ActionResult GetLeadershipProfileInfo()
        {
            var contextItem = Sitecore.Context.Item;

            LeadershipProfile leadershipProfile = new LeadershipProfile();
            leadershipProfile.LeaderName = new HtmlString(FieldRenderer.Render(contextItem, "LeaderName"));
            leadershipProfile.Des = new HtmlString(FieldRenderer.Render(contextItem, "Des")); //contextItem.Fields["Des"].Value;
            leadershipProfile.ProfileBrief = new HtmlString(FieldRenderer.Render(contextItem, "ProfileBrief")); //contextItem.Fields["ProfileBrief"].Value;
            leadershipProfile.Image = new HtmlString(FieldRenderer.Render(contextItem, "Image")); //contextItem.Fields["Image"].Value;
            LinkField linkfield = contextItem.Fields["ProfileDetail"];
            var targetItem = linkfield.TargetItem;
            leadershipProfile.DetailPageUrl = LinkManager.GetItemUrl(targetItem);

            return View("/Views/Cts/LeadershipProfile/ProfileInfo.cshtml", leadershipProfile);
        }

        public ActionResult GetLeadershipArticles()
        {
            List<Article> articleslist = new List<Article>();
            var contextItem = Sitecore.Context.Item;
            MultilistField multilistField = contextItem.Fields["Articles"];
            articleslist = multilistField.GetItems()
            .Select(x => new Article
             {
                 Title = new HtmlString(FieldRenderer.Render(x, "Title")),
                 Brief = new HtmlString(FieldRenderer.Render(x, "Brief")),
                 ArticleUrl = LinkManager.GetItemUrl(x)
             }).ToList();
            return View("/Views/Cts/LeadershipProfile/Article.cshtml", articleslist);
        }
    }
}