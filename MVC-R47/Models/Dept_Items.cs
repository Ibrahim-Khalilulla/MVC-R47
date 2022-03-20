using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_R47.Models
{
    public class Dept_Items
    {

        public int DeptId { get; set; }
        [Required(ErrorMessage = "Please enter Dept Name")]
        [Display(Name = "DeptName")]
        [MaxLength(50)]
        public string DeptName { get; set; }
        public string Location { get; set; }
        [Key]
        public int ItemCode { get; set; }//primary key and foreign Foreign Key
        public string ItemName { get; set; }
        public double Cost { get; set; }
        public double Rate { get; set; }
    }

}