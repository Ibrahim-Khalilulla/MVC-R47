using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_R47.Models
{
    public class Stu_Guard
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int GuardianId { get; set; }//primary key and foreign Foreign Key
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }

}