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
    public class StartUpJoinersController : Controller
    {
        // GET: StartUpJoiners
        public ActionResult GetListOfStartUpJoiners()
        {

            var contentItem = Sitecore.Context.Item;
            var startUpJoinerSettingsItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{CA42A65A-419A-4B9B-9049-90779BB2FF69}")) ;
            var startUpJoinersList = contentItem.GetChildren()
                                      .Where(x => x.TemplateName == "LeadershipProfile")
                                      .Where(x => CheckJoinerForStartUp(x))
                                      .Select(x => new LeadershipCard
                                      {
                                          LeaderName = x.Fields["LeaderName"].Value,
                                          LeaderProfile = x.Fields["ProfileBrief"].Value,
                                          LeaderProfileUrl = LinkManager.GetItemUrl(x)
                                      }).ToList();
            return View("/Views/Cts/Listing/StartUpJoiners.cshtml", startUpJoinersList);
        }

        public bool CheckJoinerForStartUp(Item joinerItem)
        {
            var startUpJoinerSettingsItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{CA42A65A-419A-4B9B-9049-90779BB2FF69}"));
            LinkField profileField = joinerItem.Fields["ProfileDetail"];
            DateField startDate = startUpJoinerSettingsItem.Fields["StartDate"];
            DateField endDate = startUpJoinerSettingsItem.Fields["EndDate"];
            if (profileField.IsInternal)
            {
                var profileItem = profileField.TargetItem;
                if (profileItem.TemplateName == "CTSprofile")
                {
                    DateField profileJoiningDate = profileItem.Fields["DateOfJoining"];
                    //if ((profileJoiningDate.DateTime > DateTime.Parse("01-01-2021")) && (profileJoiningDate.DateTime > DateTime.Parse("12-31-2021")))
                    if ((profileJoiningDate.DateTime > startDate.DateTime) && (profileJoiningDate.DateTime > endDate.DateTime))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
            
            
        }
    }
}