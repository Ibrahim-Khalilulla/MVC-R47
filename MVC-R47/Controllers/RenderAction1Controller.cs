using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class RenderAction1Controller : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();
        // GET: RenderAction1
        public ActionResult Index()
        {
            List<student2> a = new List<student2>();
            a = db.student2.ToList();
            return View(a);
        }

    }
}