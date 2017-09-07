using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orchard.Candidate.Net.Filters
{
    public class ExternalIdFilter : ActionFilterAttribute
    {
        public int userid;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((int?)filterContext.ActionParameters["id"] == null)
            {
                filterContext.ActionParameters["id"] = 1;
            }
        }

    }
}