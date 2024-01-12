//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDW.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dvigenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dvigenie()
        {
            this.NZP = new HashSet<NZP>();
            this.Komplekt = new HashSet<Komplekt>();
            this.NomenklaturaPlace = new HashSet<NomenklaturaPlace>();
            this.Control = new HashSet<Control>();
            this.LastDvigs = new HashSet<LastDvigs>();
        }
    
        public int Id { get; set; }
        public string FBillNo { get; set; }
        public decimal QTY { get; set; }
        public int ItemID { get; set; }
        public int POOrderId { get; set; }
        public int StockId { get; set; }
        public int Parent { get; set; }
        public decimal QTYFact { get; set; }
        public Nullable<int> QRID { get; set; }
        public int Lev { get; set; }
        public string Work { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public bool Mnimoe { get; set; }
        public bool Otmena { get; set; }
        public int StockFromId { get; set; }
        public string ZakazPostavshiku { get; set; }
        public int UserId { get; set; }
        public string NewDvigenieString { get; set; }
    
        public virtual t_Item Item { get; set; }
        public virtual t_Item Stock { get; set; }
        public virtual POOrder POOrder { get; set; }
        public virtual QRTable QRTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZP> NZP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komplekt> Komplekt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NomenklaturaPlace> NomenklaturaPlace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control> Control { get; set; }
        public virtual UsersKDW UsersKDW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LastDvigs> LastDvigs { get; set; }
    }
}