//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLKULUPLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKULUPLER()
        {
            this.TBLOGRENCILERs = new HashSet<TBLOGRENCILER>();
        }
    
        public int KULUPID { get; set; }
        public string KULUPAD { get; set; }
        public Nullable<int> KULUPKONTENJAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLOGRENCILER> TBLOGRENCILERs { get; set; }
    }
}
