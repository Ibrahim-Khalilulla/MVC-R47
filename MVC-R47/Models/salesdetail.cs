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
    
    public partial class salesdetail
    {
        public string vrno { get; set; }
        public int slno { get; set; }
        public string itemcode { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> unitprice { get; set; }
        public Nullable<decimal> totalprice { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual item item { get; set; }
    }
}
