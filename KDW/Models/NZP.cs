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
    
    public partial class NZP
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int StockId { get; set; }
        public int ItemId { get; set; }
        public decimal QTY { get; set; }
        public int POOrderId { get; set; }
        public int DvigenieId { get; set; }
        public int WorkId { get; set; }
        public int StarWorkId { get; set; }
        public System.DateTime DatePostupleniya { get; set; }
        public bool Active { get; set; }
        public Nullable<int> SOUTId { get; set; }
        public bool DvigenieNEW { get; set; }
    
        public virtual t_Item Item { get; set; }
        public virtual t_Item Stock { get; set; }
        public virtual t_Item Department { get; set; }
        public virtual POOrder POOrder { get; set; }
        public virtual Dvigenie Dvigenie { get; set; }
        public virtual ICMO ICMO { get; set; }
        public virtual StarMehWorks StarMehWorks { get; set; }
    }
}
