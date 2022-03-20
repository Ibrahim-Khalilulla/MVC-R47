using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_R47.Models;
namespace MVC_R47.Controllers
{
    public class Chapter4Controller : Controller
    {
        private cnstringEntities db = new cnstringEntities();
        public ActionResult Index()
        {
            return View(db.student2.ToList());
        }
        public ActionResult EditStudents(int id)//select-Edit
        {
            Mystudent st1 = new Mystudent();
            var st = db.student2.Find(id);//linq code
            st1.id = st.id;
            st1.name = st.name;
            st1.@class = st.@class;
            st1.fee = st.fee;
            return View(st1);//st1 is a model that is passed from controller to the view
        }
        [HttpPost]
        public ActionResult EditStudents(Mystudent myst)//Post-Button Click
        {
            var a = new Mystudent
            {
                id = myst.id,
                name = myst.name,
                @class = myst.@class,
                fee = myst.fee
            };
            ViewBag.Check = "true";
            try
            {
                student2 item = null;
                item = (from c in db.student2 where c.id == myst.id select c).FirstOrDefault();
                if (item == null)
                {
                    ViewBag.error = String.Format("Item with id {0} was not found", myst.id);
                }
                TryUpdateModel(item);
                db.SaveChanges();
                ViewBag.msg = "Successfully Updated";
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString();

            }
            return View(a);
        }

    }
}