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
    
    public partial class StocksRusKit
    {
        public string FName { get; set; }
        public string FNumber { get; set; }
        public string FEnterpriseID { get; set; }
        public string FRusName { get; set; }
        public int Id { get; set; }
        public Nullable<int> FInterID { get; set; }
    
        public virtual t_Stock t_Stock { get; set; }
        public virtual t_Item t_Item { get; set; }
    }
}