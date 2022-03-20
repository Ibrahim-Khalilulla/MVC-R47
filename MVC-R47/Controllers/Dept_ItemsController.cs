using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class Dept_ItemsController : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();
        public ActionResult Index()
        {
            List<Dept_Items> esg = new List<Dept_Items>();
            Dept_Items sg = new Dept_Items();
            IEnumerable<dept2> a = db.dept2.ToList();
            foreach (dept2 a1 in a)
            {

                List<items2> b =(from it in db.items2 where it.deptid==a1.deptid select it).ToList();
                foreach (items2 a2 in b)
                {
                    sg = new Dept_Items() { DeptId = a1.deptid, DeptName = a1.deptname, Location = a1.location, ItemCode = a2.itemcode, ItemName = a2.itemname, Cost = (double)a2.cost, Rate = (double)a2.rate };
                    esg.Add(sg);
                }
            }
            return View(esg);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items2 st = db.items2.Find(id);
            if (st == null)
            {
                return HttpNotFound();
            }
            dept2 gd = st.dept2;
            
                Dept_Items stg = new Dept_Items() { DeptId = gd.deptid, DeptName = gd.deptname, Location = gd.location, ItemCode = st.itemcode, ItemName = st.itemname, Cost = (double)st.cost, Rate = (double)st.rate };
               
            return View(stg);
        }
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult InsertDept(Dept_Items stu_Guard)
        {
            dept2 a = new dept2();
            a.deptid = stu_Guard.DeptId;
            a.deptname = stu_Guard.DeptName;
            a.location = stu_Guard.Location;
            db.dept2.Add(a);
            db.SaveChanges();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertItems(Dept_Items stu_Guard)
        {
            items2 a1 = new items2();
            a1.itemcode = stu_Guard.ItemCode;
            a1.itemname = stu_Guard.ItemName;
            a1.deptid = stu_Guard.DeptId;
            a1.cost = (decimal)stu_Guard.Cost;
            a1.rate = (decimal)stu_Guard.Rate;
            db.items2.Add(a1);
            db.SaveChanges();
            return Json(a1, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dept_Items stu_Guard)
        {
            
                dept2 a = new dept2();
                a.deptid = stu_Guard.DeptId;
                a.deptname = stu_Guard.DeptName;
                a.location = stu_Guard.Location;
                items2 a1 = new items2();
                a1.itemcode = stu_Guard.ItemCode;
                a1.itemname = stu_Guard.ItemName;
                a1.deptid = stu_Guard.DeptId;
                a1.cost = (decimal)stu_Guard.Cost;
                a1.rate = (decimal)stu_Guard.Rate;
                dept2 d2 = db.dept2.Find(stu_Guard.DeptId);
                if (d2 == null)
                {
                    db.dept2.Add(a);
                }
                else
                {
                    ViewBag.DeptError = "The dept already exists";
                }
                if (stu_Guard.ItemCode.ToString() != "")
                {
                    db.items2.Add(a1);
                }
                db.SaveChanges();
                return RedirectToAction("Index");            
            
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept_Items sg = new Dept_Items();
            items2 a1 = db.items2.Find(id);
            if (a1 != null)
            {
                dept2 b = db.dept2.Find(a1.deptid);
                sg = new Dept_Items() { DeptId = b.deptid, DeptName = b.deptname, Location = b.location, ItemCode = a1.itemcode, ItemName = a1.itemname, Cost = (double)a1.cost, Rate = (double)a1.rate };
            }
            return View(sg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dept_Items stu_Guard)
        {
            if (ModelState.IsValid)
            {
                dept2 st5 = db.dept2.Find(stu_Guard.DeptId);
                st5.deptname = stu_Guard.DeptName;
                st5.location = stu_Guard.Location;
                items2 gd5 = db.items2.Find(stu_Guard.ItemCode);
                gd5.itemname = stu_Guard.ItemName;
                gd5.cost = (decimal)stu_Guard.Cost;
                gd5.rate = (decimal)stu_Guard.Rate;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_Guard);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept_Items sg = new Dept_Items();
            items2 a1 = db.items2.Find(id);
            if (a1 != null)
            {
                dept2 b = db.dept2.Find(a1.deptid);
                sg = new Dept_Items() { DeptId = b.deptid, DeptName = b.deptname, Location = b.location, ItemCode = a1.itemcode, ItemName = a1.itemname, Cost = (double)a1.cost, Rate = (double)a1.rate };
            }
            return View(sg);
        }
        public JsonResult DeleteAll(int id)
        {

            List<items2> st5 = db.items2.Where(xx=>xx.deptid==id).ToList();
            db.items2.RemoveRange(st5);

            dept2 st6 = db.dept2.Find(id);
            if (st6 != null)
            {
                db.dept2.Remove(st6);
            }
            db.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
            [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            items2 st5 = db.items2.Find(id);
            var a = (from i in db.items2 where i.itemcode == id select new { i.deptid }).FirstOrDefault();
            dept2 st6 = db.dept2.Find(a.deptid);
            var fk = (from d in db.items2 where d.deptid== a.deptid select d).ToList();
            if (fk.Count <= 1)
            {
                db.dept2.Remove(st6);
            }
            db.items2.Remove(st5);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult GetDept(int id)
        {
            var a = (from d in db.dept2 where d.deptid==id select new { d.deptid,d.deptname,d.location});
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItems(int id)
        {
            var a = (from d in db.items2 where d.deptid == id select new { d.itemcode, d.itemname, d.cost,d.rate });
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowMe()
        {
            List<dept2> s = db.dept2.ToList();
            return View(s);
        }
        [ChildActionOnly]
        public ActionResult ShowItems(int sid=0)
        {
            List<items2> s = db.items2.Where(xx => xx.deptid == sid).ToList();
            return View(s);
        }
       [ChildActionOnly]
        public ActionResult Create2(int sid = 0)
        {
            ViewBag.sid = sid;
            return View();
        }
    }

}
