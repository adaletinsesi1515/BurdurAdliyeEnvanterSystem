//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BurdurAdliyeEnvanterSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLMARKALAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMARKALAR()
        {
            this.TBLBILGISAYARLAR = new HashSet<TBLBILGISAYARLAR>();
            this.TBLMODELLER = new HashSet<TBLMODELLER>();
            this.TBLTARAYICILAR = new HashSet<TBLTARAYICILAR>();
            this.TBLYAZICILAR = new HashSet<TBLYAZICILAR>();
        }
    
        public int ID { get; set; }
        public string MARKAADI { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLBILGISAYARLAR> TBLBILGISAYARLAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLMODELLER> TBLMODELLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLTARAYICILAR> TBLTARAYICILAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLYAZICILAR> TBLYAZICILAR { get; set; }
    }
}