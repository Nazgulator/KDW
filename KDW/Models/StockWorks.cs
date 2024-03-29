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
    
    public partial class StockWorks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockWorks()
        {
            this.StockWorkEntrys = new HashSet<StockWorkEntrys>();
            this.PredNZP = new HashSet<PredNZP>();
        }
    
        public int Id { get; set; }
        public int WorkId { get; set; }
        public string WorkNumber { get; set; }
        public int Poryadok { get; set; }
        public decimal QTY { get; set; }
        public decimal QTYFact { get; set; }
        public bool Complete { get; set; }
        public string Prichina { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public int UserId { get; set; }
        public Nullable<int> StockId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockWorkEntrys> StockWorkEntrys { get; set; }
        public virtual ICMO ICMO { get; set; }
        public virtual t_Stock t_Stock { get; set; }
        public virtual UsersKDW UsersKDW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PredNZP> PredNZP { get; set; }
    }
}
