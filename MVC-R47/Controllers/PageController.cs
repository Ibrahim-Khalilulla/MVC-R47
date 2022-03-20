using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_R47.Models;
namespace MVC_R47.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Page1()
        {
            ViewBag.Message = "Welcome to Page1";
            return View();
        }
        [HttpGet]
        [Route("hello")]
        public ActionResult Page2()
        {
            ViewBag.Message = "Welcome to Page2";
            return View();
        }
        //[NonAction]
        public ActionResult Page3()
        {
            ViewBag.Message = "Welcome to Page3";
            List<AddingNumbers> add = new List<AddingNumbers>();
            add.Add(new AddingNumbers { Number1 = 2, Number2 = 4, OutputNumber = 6 });
            add.Add(new AddingNumbers { Number1 = 1, Number2 = 2, OutputNumber = 3 });
            add.Add(new AddingNumbers { Number1 = 1, Number2 = 4, OutputNumber = 5 });
            add.Add(new AddingNumbers { Number1 = 2, Number2 = 5, OutputNumber = 7 });
            return View(add);
        }
        [ActionName("MyAction")]
        public ActionResult Page4()
        {
            ViewBag.Message = "Welcome to Page4";
            return View();
        }
        public ViewResult Page6()
        {
            ViewBag.Message = "RouteData from RouteConfig.cs";
            var data = RouteData.Values["controller"] ?? String.Empty;
            var data2 = RouteData.Values["action"] ?? String.Empty;
            var data3 = RouteData.Values["id"] ?? "No Id";
            var data4 = Request["name"] ?? "no query string";
            ViewBag.Data = "Controller name is :" + data;
            ViewBag.Data2 = "Action name is :" + data2;
            ViewBag.Data3 = "Parameter name is :" + data3;
            ViewBag.Data4 = "Querystring:name is :" + data4;
            return View();
        }

        public JavaScriptResult GetScript()
        {
            var script = "alert('Hello')";
            return JavaScript(script);
        }
        public JsonResult GetMyJson()
        {
            cnstringEntities a = new cnstringEntities();
            return Json(a.foodMenuTBs.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ViewResult GetByHtmlView()
        {
            cnstringEntities a = new cnstringEntities();
            var b=a.foodMenuTBs.ToList();
            return View(b);
        }
        [HttpGet]
        public ViewResult AddNumbers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNumbers(Numbers a)
        {
            if (ModelState.IsValid)
            {
                a.OutputNumber = a.Number1 + a.Number2;
                ViewBag.ot = a.OutputNumber;
                return View("Page7",a);
            }
            return View(a);
        }
        public ActionResult Page7()
        {
            return View();
        }

        //display to add two numbers
        [HttpGet]
        public ViewResult AddingNumbers()
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = "Num_";
            return View();
        }
        //submit button work
        [HttpPost]
        public ActionResult AddingNumbers([Bind(Prefix = "Num_")] AddingNumbers a)
        {
            if (ModelState.IsValid)
            {
                a.OutputNumber = a.Number1 + a.Number2;
                //from controller to view, data can be passed in three ways
                //first way: viewBag
                ViewBag.ot = a.OutputNumber;
                //second way: viewData
                ViewData["ot"] = a.OutputNumber;
                //third way: ModelData
                return View("Page8", a);
            }
            return View(a);
        }
        [ChildActionOnly]
        public ActionResult Page9()
        {
            cnstringEntities a = new cnstringEntities();
            var b = a.foodMenuTBs.ToList();//all records from foodmenutb has been fetched
            return View(b);
        }
        public ActionResult Page10()
        {
            return View();
        }

    }
}