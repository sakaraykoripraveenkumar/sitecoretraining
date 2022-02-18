using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTS.Project.CTS.Models
{
    public class LeadershipProfile
    {
        public HtmlString LeaderName { get; set; }
        public HtmlString Des { get; set; }
        public HtmlString ProfileBrief { get; set; }
        public HtmlString Image { get; set; }

        public string DetailPageUrl { get; set; }

    }
}