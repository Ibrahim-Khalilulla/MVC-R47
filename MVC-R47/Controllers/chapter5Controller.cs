using MVC_R47.Models;
using MVC_R47.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    [Authorize]
    public class chapter5Controller : Controller
    {
        private IChapter5 _db;
        public chapter5Controller()
        {
            _db = new Chapter5();//worker service class. It resides in default constructor
        }
        //A second constructor is available to manually inject any instance you like, at least for testability reasons.
        public chapter5Controller(IChapter5 ch5)//this is the sign of poor man's di
        {
            _db = ch5;
        }
        public void CommonMethod()
        {
            ViewBag.records = _db.CommonMethod();
        }
       // [ChildActionOnly]
        public ActionResult Index(int id=0)
        {
            ViewBag.msg = TempData["msg"];
            CommonMethod();
            if (id == 0)
            {
               return View();
            }
            else
            {
                return View(_db.GetAll(id));
            }
        }



        [HttpAction1]
        [HttpPost]
        public ActionResult create(Mystudent2 myst)
        {
            CommonMethod();
            
            if (ModelState.IsValid)
            {
               string h = _db.Create(myst);
                TempData["msg"] = h;
                Session["msg"] = h;
                return RedirectToAction("Index");
            }
            return View("index");
        }

        [HttpAction1]
        [HttpPost]
        public ActionResult edit(Mystudent2 myst)//Post-Button Click
        {
            CommonMethod();
            if (ModelState.IsValid)
            {
                TempData["msg"] = _db.Update(myst);
                return RedirectToAction("Index");
            }
            return View(myst);
        }

        [HttpAction1]
        [HttpPost]
        public ActionResult delete(int id)
        {
            CommonMethod();
            TempData["msg"] = _db.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult Index1(int id = 0)
        {
            //ViewBag.msg = TempData["msg"];
            //CommonMethod();
            if (id == 0)
            {
                return Json(_db.GetAll1(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //return View(_db.GetAll(id));
                return Json(_db.GetAll(id), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult create1(Mystudent2 myst)
        {
            if (ModelState.IsValid)
            {
                string h = _db.Create(myst);
                TempData["msg"] = h;
                Session["msg"] = h;
                return RedirectToAction("Index");
            }
            return View("index");
        }

    }
}