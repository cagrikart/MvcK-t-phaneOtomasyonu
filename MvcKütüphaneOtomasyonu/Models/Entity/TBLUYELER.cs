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
    
    public partial class TBLUYELER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUYELER()
        {
            this.TBLHAREKET = new HashSet<TBLHAREKET>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string MAİL { get; set; }
        public string KULLANİCİADİ { get; set; }
        public string ŞİFRE { get; set; }
        public string FOTOGRAF { get; set; }
        public string TELEFON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }
    }
}
