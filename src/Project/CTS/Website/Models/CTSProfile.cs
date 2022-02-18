using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTS.Project.CTS.Models
{
    public class CTSProfile
    {
        public HtmlString FirstName { set; get; }
        public HtmlString LastName { set; get; }
        public HtmlString EmailId { set; get; }

        public string DetailPageUrl { get; set; }


        public HtmlString DateOfJoining { get; set; }

        public DateTime JoiningDate { get; set; }

    }
}