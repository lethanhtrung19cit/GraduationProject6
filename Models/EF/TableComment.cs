//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GraduationProject.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableComment
    {
        public int IdCommnet { get; set; }
        public string IdGoods { get; set; }
        public string IdCu { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public string Comment { get; set; }
        public Nullable<byte> Quality { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Good Good { get; set; }
    }
}
