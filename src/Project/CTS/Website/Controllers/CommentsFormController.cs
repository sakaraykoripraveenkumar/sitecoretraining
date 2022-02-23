using CTS.Project.CTS.Models;
using Sitecore.Data;
using Sitecore.Publishing;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTS.Project.CTS.Controllers
{
    public class CommentsFormController : Controller
    {
        // GET: CommentsForm
        [HttpGet]
        public ActionResult CommentsFormAction()
        {
            Comment comment = new Comment();
            return View("/Views/Cts/LeadershipProfile/CommnetsForm.cshtml", comment);
        }

        [HttpPost]
        public ActionResult CommentsFormAction(Comment comment)
        {
            TemplateID templateID = new TemplateID(new ID("{319539F3-D5BC-43D8-8AE1-64D25FFE0874}"));
            var parentItem = Sitecore.Context.Item;
            var masterDB= Sitecore.Configuration.Factory.GetDatabase("master");
            var webDB = Sitecore.Configuration.Factory.GetDatabase("web");
            var parentItemfromMasterDB = masterDB.GetItem(parentItem.ID);
            using (new SecurityDisabler())
            {
                var commentsItem = parentItemfromMasterDB.Add(comment.Name, templateID);
                commentsItem.Editing.BeginEdit();
                commentsItem["Comments"] = comment.Comments;
                commentsItem["Name"] = comment.Name;
                commentsItem["EmailId"] = comment.EmailId;
                commentsItem.Editing.EndEdit();
                PublishOptions publishOptions = new PublishOptions(masterDB, webDB, PublishMode.SingleItem, Sitecore.Context.Language, DateTime.Now);
                Publisher publisher = new Publisher(publishOptions);
                publisher.Options.RootItem = commentsItem;
                publisher.Options.Deep = true;
                publisher.Options.Mode = PublishMode.SingleItem;
                publisher.Publish();
            }
            return View("/Views/Cts/LeadershipProfile/ThankYou.cshtml");
        }
    }
}