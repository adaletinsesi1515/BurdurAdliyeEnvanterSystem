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
    
    public partial class TBLTONERCIKIS
    {
        public int ID { get; set; }
        public Nullable<int> TONERSTOKID { get; set; }
        public Nullable<int> ZIMMETID { get; set; }
        public Nullable<int> TONERADET { get; set; }
        public Nullable<int> DRUMADET { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<int> KULLANICIID { get; set; }
    
        public virtual TBLKULLANICILAR TBLKULLANICILAR { get; set; }
        public virtual TBLTONERSTOK TBLTONERSTOK { get; set; }
        public virtual TBLZIMMET TBLZIMMET { get; set; }
    }
}