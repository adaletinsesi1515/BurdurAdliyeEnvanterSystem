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
    
    public partial class TBLPERSONELLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPERSONELLER()
        {
            this.TBLZIMMET = new HashSet<TBLZIMMET>();
        }
    
        public int ID { get; set; }
        public string SICIL { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public Nullable<int> UNVANID { get; set; }
        public Nullable<int> BIRIMID { get; set; }
        public string DAHILITEL { get; set; }
        public string CEPTEL { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        public virtual TBLBIRIMLER TBLBIRIMLER { get; set; }
        public virtual TBLUNVANLAR TBLUNVANLAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLZIMMET> TBLZIMMET { get; set; }
    }
}
