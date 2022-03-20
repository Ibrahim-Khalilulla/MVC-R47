using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class Chapter4fourController : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();
        // GET: Chapter4Vm
        List<Mystudent4> a = new List<Mystudent4>();
        public ActionResult Index()
        {
            //adding data from it's default model(edmx) to my created ViewModel(MyStudent4)
            foreach (var d in db.student2.ToList())
            {
                a.Add(new Mystudent4() { id = d.id, name = d.name, fee = d.fee, @class = d.@class });
            }
            return View(a);
        }
    }
}