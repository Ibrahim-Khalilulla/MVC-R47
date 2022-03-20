using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class Chapter4thirdController : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();
        // GET: Chapter4third
        List<MyStudent3> a = new List<MyStudent3>();
        public ActionResult Index()
        {
            foreach (var d in db.student2.ToList())
            {
                a.Add(new MyStudent3() { id = d.id, name = d.name, fee = d.fee, @class = d.@class });
            }
            return View(a);
        }
    }
}