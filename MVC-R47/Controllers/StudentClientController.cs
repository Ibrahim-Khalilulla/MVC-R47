using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class StudentClientController : Controller
    {
        // GET: StudentClient
       [ChildActionOnly]
        public ActionResult Index()
        {
            return View();
        }
    }
}