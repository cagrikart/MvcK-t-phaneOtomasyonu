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
    
    public partial class TBLKİTAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKİTAP()
        {
            this.TBLHAREKET = new HashSet<TBLHAREKET>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public Nullable<byte> KATEGORİ { get; set; }
        public Nullable<int> YAZAR { get; set; }
        public string BASİMYİL { get; set; }
        public string YAYİNEVİ { get; set; }
        public string SAYFA { get; set; }
        public Nullable<bool> DURUM { get; set; }
        public string KİTAPRESİM { get; set; }
    
        public virtual TBLCATEGORY TBLCATEGORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }
        public virtual TBLYAZAR TBLYAZAR { get; set; }
    }
}
