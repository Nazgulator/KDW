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
    
    public partial class InventVedomost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventVedomost()
        {
            this.InventQR = new HashSet<InventQR>();
        }
    
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal QTY { get; set; }
        public decimal QTYFact { get; set; }
        public System.DateTime StartDate { get; set; }
        public int UserId { get; set; }
        public decimal QTYProhod2 { get; set; }
        public decimal QTYProhod3 { get; set; }
        public int UserId2 { get; set; }
        public int UserId3 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventQR> InventQR { get; set; }
        public virtual t_Item t_Item { get; set; }
        public virtual UsersKDW UsersKDW { get; set; }
    }
}
