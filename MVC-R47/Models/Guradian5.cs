//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_R47.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guradian5
    {
        public int GuardianID { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<int> StudentsId { get; set; }
    
        public virtual student5 student5 { get; set; }
    }
}
