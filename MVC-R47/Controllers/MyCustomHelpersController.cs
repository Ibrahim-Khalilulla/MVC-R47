using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class MyCustomHelpersController : Controller
    {
        public ActionResult MyStaticCustomHelper()
        {
            return View();
        }

    }
}