using CTS.Project.CTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTS.Project.CTS.Controllers
{
    public class DisplayCommentsController : Controller
    {
        // GET: DisplayComments
        public ActionResult DisplayComment()
        {
            var contextItem = Sitecore.Context.Item;
            var CommentList = contextItem.GetChildren()
                .Where(x => x.TemplateName == "Comment")
                .Select(x => new Comment
                {
                    Comments = x.Fields["Comments"].Value,
                    Name = x.Fields["Name"].Value,
                    EmailId = x.Fields["EmailId"].Value,

                }).ToList();

            return View("/Views/Cts/LeadershipProfile/DisplayComments.cshtml", CommentList);
        }
    }
}