﻿using CTS.Project.CTS.Models;
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
            var startUpJoinersList = contentItem.GetChildren()
                                      .Where(x => x.TemplateName == "LeadershipProfile")
                                      .Where(x => CheckJoinerForStartUp(x))
                                      .Select(x => new LeadershipCard
                                      {
                                          LeaderName = x.Fields["LeaderName"].Value,
                                          LeaderProfile = x.Fields["ProfileBrief"].Value,
                                          LeaderProfileUrl = LinkManager.GetItemUrl(x)
                                      }).ToList();
            return View("/Views/Cts/Listing/StartUpJoiners.cshtml");
        }

        public bool CheckJoinerForStartUp(Item joinerItem)
        {
            LinkField profileField = joinerItem.Fields["ProfileDetail"];

            if (profileField.IsInternal)
            {
                var profileItem = profileField.TargetItem;
                if (profileItem.TemplateName == "CTSprofile")
                {
                    DateField profileJoiningDate = profileItem.Fields["DateOfJoining"];
                    if ((profileJoiningDate.DateTime > DateTime.Parse("01-01-2021")) && (profileJoiningDate.DateTime > DateTime.Parse("31-12-2021")))

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