using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_R47.Models
{
    public class Mystudent//properties are created from the fields of the table with same datatype
    {
        [Required(ErrorMessage = "Please enter id")]
        [Display(Name = "id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string name { get; set; }


        public string @class { get; set; }
        public Nullable<decimal> fee { get; set; }
    }

}