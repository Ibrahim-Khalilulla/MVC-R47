using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class TwoTableByListController : Controller
    {
        private cm_restoEntities db = new cm_restoEntities();
        List<detail> sdt = new List<detail>();
        List<master> mst = new List<master>();

        public ActionResult Index()
        {
            int t = 0;
            Session["sdt"] = TempData["sdt"];
            
            ViewBag.records = Session["sdt"];
            if (ViewBag.records != null)
            {
                foreach (var k in ViewBag.records)
                {
                    t += k.totalprice;
                }
            }
            ViewBag.t = t;
            TempData["sdt"]= Session["sdt"];
            ViewBag.sid = GenerateCode();
            string dt = DateTime.Now.Year+"-"+ DateTime.Now.Month + "-" + DateTime.Now.Day;
            ViewBag.date = dt;
            return View();
        }
        public List<detail> AllDetails()
        {
            ViewBag.sid = GenerateCode();
            return db.details.ToList();
        }
        [HttpAction1]
        [HttpPost]
        public ActionResult AddDetails(detail d,master m)
        {
            // int sl = (from d1 in sdt select d1).DefaultIfEmpty().Max(x=>x.slno);
            sdt= TempData["sdt"] as List<detail>;
            int sl = 0;
            if (sdt != null)
            sl=sdt.Select(f => f.slno).DefaultIfEmpty(0).Max();
            else
                sdt = new List<detail>();
            sl++;
            sdt.Add(new detail() { salesid = d.salesid,slno=sl, itemcode = d.itemcode, itemname = d.itemname, qty = d.qty, unitprice = d.unitprice, totalprice = d.qty*d.unitprice });
            TempData["sdt"] = sdt;
            //return Json("OK", JsonRequestBehavior.AllowGet);
            ViewBag.sid = GenerateCode();
            return RedirectToAction("Index");
        }

        [HttpAction1]
        [HttpPost]
        public ActionResult Save(master m2)
        {
            ViewBag.sid = GenerateCode();
            master m = new master() { date = DateTime.Parse("2021-12-13"), salesid = m2.salesid, party = m2.party, total = m2.total, discount = m2.discount, gross = m2.gross, paid = 0, due = 0 };
            db.masters.Add(m);
            db.SaveChanges();
            sdt = TempData["sdt"] as List<detail>;
            foreach (detail a in sdt)
            {
                db.details.Add(a);
                db.SaveChanges();
            }
            
            TempData["sdt"] = "";
            return RedirectToAction("Index");
        }
            public JsonResult GetDetails()
        {
            sdt = TempData["sdt"] as List<detail>;
            TempData["sdt"] = sdt;
            return Json(sdt, JsonRequestBehavior.AllowGet);
        }
        public string GenerateCode()
        {
            string a1="";
            string b1 = "";

            try
            {
                var a = (from det in db.details select  det.salesid.Substring(3)).Max();
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "AC-" + b1.ToString();
            }
            catch(Exception ex)
            {
                a1 = "AC-0001";
            }
            return a1;
        }
    }
}