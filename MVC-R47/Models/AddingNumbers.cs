using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC_R47.Models
{
    [Bind(Prefix  = "Num")]
    public class AddingNumbers
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int OutputNumber { get; set; }
    }
}