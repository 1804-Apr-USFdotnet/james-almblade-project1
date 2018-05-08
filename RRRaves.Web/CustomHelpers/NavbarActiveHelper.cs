using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RRRaves.Web.Custom_Helpers
{
    public static class NavbarActiveHelper
    {
        public static MvcHtmlString NavActionLink(this HtmlHelper helper, string text, string action, string controller)
        {
            string navstring;
            var context = helper.ViewContext;
            if (context.Controller.ControllerContext.IsChildAction)
            {
                context = helper.ViewContext.ParentActionViewContext;
            }

            var route = context.RouteData.Values;
            var currentact = route["action"].ToString();
            var currentcont = route["controller"].ToString();

            navstring = String.Format("<li class=\"nav-item\"> {0} </li>",
            currentact.Equals(action, StringComparison.InvariantCulture) &&
            currentcont.Equals(controller, StringComparison.InvariantCulture)
            ? helper.ActionLink(text, action, controller, null, new { @class = "nav-link active" }).ToHtmlString()
            : helper.ActionLink(text, action, controller, null, new { @class = "nav-link" }).ToHtmlString());

            return new MvcHtmlString(navstring);
        }
    }
}