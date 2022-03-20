using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Filters
{
    public class mycustomfilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var descriptor = filterContext.ActionDescriptor;
            //var ActionParameter = filterContext.ActionParameters;
            //var actionName = descriptor.ActionName;
            //var controllerName = descriptor.ControllerDescriptor.ControllerName;
            //cm_restoEntities db = new cm_restoEntities();
            //logcustomfilter lcf = new logcustomfilter();
            //lcf.summary = $"Controler is: {controllerName}, action is:{actionName}";
            //lcf.inputtime = Convert.ToDateTime(DateTime.Now);// DateTime.Now.ToLocalTime
            //db.logcustomfilters.Add(lcf);
            //db.SaveChanges();
            //Debug.WriteLine($"Controler is: {controllerName}, action is:{actionName}");
        }

    }
}