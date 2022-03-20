using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.ActionInvoker
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName.Equals("About", StringComparison.CurrentCultureIgnoreCase))
            {
                controllerContext.HttpContext.Response.Write("This should be the home page");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}