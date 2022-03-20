using MVC_R47.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Controllers
{
    public class MathCalculationController : Controller
    {
        List<SelectListItem> listItems = new List<SelectListItem>();
        public ActionResult Index()
        {
            PopulateComBo();
            ViewBag.Operations = new SelectList(listItems, "Value", "Text");
            return View();
        }
        [HttpAction1]
        [HttpPost]
        public ActionResult Index1(MathCalculation a)
        {
            PopulateComBo();
            ViewBag.Operations = new SelectList(listItems, "Value", "Text");
            int add =a.Number1+a.Number2;
            int sub = a.Number1 - a.Number2;
            int mul = a.Number1 * a.Number2;
            int div = a.Number1 / a.Number2;
            MathCalculation b = new MathCalculation();
            b.result = $"Addition is: {add}, Subtraction is:{sub}, Multilplication is:{mul}, Division is:{div}";
            ViewBag.onb = b.result;
            return View("Index", b);
        }


        [HttpAction1]
        [HttpPost]
        public ActionResult Add(MathCalculation a)
        {

            PopulateComBo();

            ViewBag.Operations = new SelectList(listItems, "Value", "Text");
            if (a.operation == "Addition")
                a.outputNumber = a.Number1 + a.Number2;
            else if (a.operation == "Subtraction")
                a.outputNumber = a.Number1 - a.Number2;
            else if (a.operation == "Multiplication")
                a.outputNumber = a.Number1 * a.Number2;
            else if (a.operation == "Division")
                a.outputNumber = a.Number1 / a.Number2;


            MathCalculation b = new MathCalculation();
            b.outputNumber = a.outputNumber;
            ViewBag.onb = a.outputNumber;
            return View("Index", b);
        }




            private void PopulateComBo()
        {

            listItems.Add(new SelectListItem
            {
                Text = "Addition",
                Value = "Addition"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Subtraction",
                Value = "Subtraction"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Multiplication",
                Value = "Multiplication"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Division",
                Value = "Division"
            });

        }
    }
}