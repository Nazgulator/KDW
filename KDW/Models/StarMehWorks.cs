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
    
    public partial class StarMehWorks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StarMehWorks()
        {
            this.NZP = new HashSet<NZP>();
        }
    
        public int Id { get; set; }
        public string WorkNumber { get; set; }
        public int WorkId { get; set; }
        public int StMehId { get; set; }
        public int Poryadok { get; set; }
        public decimal QTY { get; set; }
        public decimal QTYFact { get; set; }
        public bool Complete { get; set; }
        public string Prichina { get; set; }
        public int PlanshetId { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public Nullable<System.DateTime> WorkDate { get; set; }
        public Nullable<int> PlanoviWorkId { get; set; }
    
        public virtual ICMO ICMO { get; set; }
        public virtual ComputerNames ComputerNames { get; set; }
        public virtual t_Item t_Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZP> NZP { get; set; }
    }
}