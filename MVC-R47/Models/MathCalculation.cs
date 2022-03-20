using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_R47.Models
{
    public class MathCalculation
    {
        public int Number1 { get; set; }//textbox/editorfor

        public int Number2 { get; set; }//textbox/editorfor
        public int outputNumber { get; set; }//label
        public string operation { get; set; }//combobox
        public string result { get; set; }//output string

    }
}