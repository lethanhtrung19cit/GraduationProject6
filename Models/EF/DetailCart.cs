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
    
    public partial class DetailCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DetailCart()
        {
            this.DetailOrders = new HashSet<DetailOrder>();
        }
    
        public int IdDeCart { get; set; }
        public Nullable<int> IdCart { get; set; }
        public string IdGoods { get; set; }
        public int Amount { get; set; }
        public Nullable<float> SumMoney { get; set; }
        public string Status { get; set; }
        public int ReadyBuy { get; set; }
    
        public virtual Cart Cart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }
    }
}