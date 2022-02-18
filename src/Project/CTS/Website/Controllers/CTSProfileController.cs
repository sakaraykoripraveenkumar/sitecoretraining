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
    public class CTSProfileController : Controller
    {
        // GET: CTSProfile
        public ActionResult GetCTSProfileInfo()
        {
            var contextItem = Sitecore.Context.Item;
            
            CTSProfile ctsProfile = new CTSProfile();

            ctsProfile.FirstName = new HtmlString(FieldRenderer.Render(contextItem, "FirstName"));

            ctsProfile.LastName = new HtmlString(FieldRenderer.Render(contextItem, "LastName"));

            ctsProfile.EmailId = new HtmlString(FieldRenderer.Render(contextItem, "EmailId"));

             LinkField linkfield = contextItem.Fields["ProfileDetail"];
            var targetItem = linkfield.TargetItem;
            DateField dateField = contextItem.Fields["DateOfJoining"];

            ctsProfile.DateOfJoining = new HtmlString(FieldRenderer.Render(contextItem, "DateOfJoining"));
            ctsProfile.JoiningDate = dateField.DateTime;

            ctsProfile.DetailPageUrl = LinkManager.GetItemUrl(targetItem);

       

            return View("/Views/Cts/LeadershipProfile/CTSProfile.cshtml", ctsProfile);
        }
    }
}