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
    
    public partial class DepartmentToStocks
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int PlanshetId { get; set; }
        public int StockId { get; set; }
        public int MolId { get; set; }
        public bool Main { get; set; }
        public string NameRus { get; set; }
        public int BufferStockId { get; set; }
    
        public virtual t_Item Department { get; set; }
        public virtual t_Item Stock { get; set; }
        public virtual ComputerNames ComputerNames { get; set; }
        public virtual t_Item MOL { get; set; }
    }
}
