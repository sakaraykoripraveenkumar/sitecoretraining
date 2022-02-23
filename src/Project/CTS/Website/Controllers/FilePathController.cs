using CTS.Project.CTS.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CTS.Project.CTS.Controllers
{
    public class FilePathController : Controller
    {
        // GET: FilePath
        public ActionResult GetBreadcrumb()
        {
            var contextItem = Sitecore.Context.Item;
            //contextItem.Axes.
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            NavigationItem currentItemNav = new NavigationItem
            {
                NavTitle = contextItem.DisplayName,
                NavUrl = LinkManager.GetItemUrl(contextItem)
            };
            var navIteamList = contextItem.Axes.GetAncestors()
                .Where(x=>x.Axes.IsDescendantOf(homeItem))
                //.Where(x => x.Fields["IsNavigable"] != null && x.Fields["IsNavigable"].Value == "1")
                .Where(x => CheckForNavigableOption(homeItem))
                .Select(x => new NavigationItem
                {
                    NavTitle = x.DisplayName,
                    NavUrl = LinkManager.GetItemUrl(x)
                })
                .Concat(new List<NavigationItem> { currentItemNav });
            return View("/Views/Cts/Common/Breadcrumb.cshtml",navIteamList);
        }

        private bool CheckForNavigableOption(Item item)
        {
          CheckboxField checkBox = item.Fields["IsNavigable"];
            return checkBox.Checked;
        }
    }
}