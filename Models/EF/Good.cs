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
    
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            this.DisCounts = new HashSet<DisCount>();
            this.SubImages = new HashSet<SubImage>();
            this.TableComments = new HashSet<TableComment>();
        }
    
        public string IdGoods { get; set; }
        public Nullable<int> IdTypeG { get; set; }
        public string NameGoods { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public Nullable<int> Amount { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Recommend { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisCount> DisCounts { get; set; }
        public virtual ListTypeGood ListTypeGood { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubImage> SubImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableComment> TableComments { get; set; }
    }
}
