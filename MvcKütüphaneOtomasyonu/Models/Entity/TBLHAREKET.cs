//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKütüphaneOtomasyonu.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLHAREKET
    {
        public int ID { get; set; }
        public int KITAP { get; set; }
        public int UYE { get; set; }
        public int PERSONEL { get; set; }
        public System.DateTime ALİSTARİHİ { get; set; }
        public System.DateTime İADETARİHİ { get; set; }
        public Nullable<System.DateTime> UYEGETİRTARİH { get; set; }
        public Nullable<bool> İSLEMDURUM { get; set; }
    
        public virtual TBLKİTAP TBLKİTAP { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL1 { get; set; }
        public virtual TBLUYELER TBLUYELER { get; set; }
    }
}
