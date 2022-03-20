using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class Stu_GuardController : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();
        //[ChildActionOnly]
        public ActionResult Index()
        {
            
            List<Stu_Guard> esg = new List<Stu_Guard>();
            Stu_Guard sg = new Stu_Guard();
            IEnumerable<student5> a = db.student5.ToList();
            foreach (student5 a1 in a)
            {
                Guradian5 b = db.Guradian5.Find(a1.ID);
                sg = new Stu_Guard() { ID = a1.ID, Name = a1.Name, Class = a1.Class, GuardianId = b.GuardianID, FatherName = b.FatherName, MotherName = b.MotherName };
                esg.Add(sg);
            }
            return View(esg);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student5 st = db.student5.Find(id);
            if (st == null)
            {
                return HttpNotFound();
            }
            Guradian5 gd = st.Guradian5.First();
            Stu_Guard stg = new Stu_Guard() { ID = st.ID, Name = st.Name, Class = st.Class, FatherName = gd.FatherName, MotherName = gd.MotherName,GuardianId=gd.GuardianID };

            return View(stg);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Class,GuardianId,FatherName,MotherName")] Stu_Guard stu_Guard)
        {
            if (ModelState.IsValid)
            {
                student5 a = new student5();
                a.ID = stu_Guard.ID;
                a.Name = stu_Guard.Name;
                a.Class = stu_Guard.Class;
                Guradian5 a1 = new Guradian5();
                a1.GuardianID = stu_Guard.GuardianId;
                a1.FatherName = stu_Guard.FatherName;
                a1.MotherName = stu_Guard.MotherName;
                a1.StudentsId = stu_Guard.ID;
                db.student5.Add(a);
                db.Guradian5.Add(a1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_Guard);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stu_Guard sg = new Stu_Guard();
            student5 a1 = db.student5.Find(id);
            if (a1 != null)
            {
                Guradian5 b = db.Guradian5.Find(a1.ID);
                sg = new Stu_Guard() { ID = a1.ID, Name = a1.Name, Class = a1.Class, GuardianId = b.GuardianID, FatherName = b.FatherName, MotherName = b.MotherName };
            }
            return View(sg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Class,GuardianId,FatherName,MotherName")] Stu_Guard stu_Guard)
        {
            if (ModelState.IsValid)
            {
                student5 st5 = db.student5.Find(stu_Guard.ID);
                st5.Name = stu_Guard.Name;
                st5.Class = stu_Guard.Class;
                Guradian5 gd5 = db.Guradian5.Find(stu_Guard.GuardianId);
                gd5.FatherName = stu_Guard.FatherName;
                gd5.MotherName = stu_Guard.MotherName;
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
            Stu_Guard sg = new Stu_Guard();
            student5 a1 = db.student5.Find(id);
            if (a1 != null)
            {
                Guradian5 b = db.Guradian5.Find(a1.ID);
                sg = new Stu_Guard() { ID = a1.ID, Name = a1.Name, Class = a1.Class, GuardianId = b.GuardianID, FatherName = b.FatherName, MotherName = b.MotherName };
            }
            return View(sg);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student5 st5 = db.student5.Find(id);
            db.student5.Remove(st5);
            Guradian5 st6 = db.Guradian5.Find(id);
            db.Guradian5.Remove(st6);
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

    }
}