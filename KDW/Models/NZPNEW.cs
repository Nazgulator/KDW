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
    
    public partial class NZPNEW
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public int DepartmentId { get; set; }
        public int FromStockId { get; set; }
        public int FromDvigenieNEWId { get; set; }
        public string QRString { get; set; }
        public int ItemId { get; set; }
        public decimal QTYFact { get; set; }
        public decimal QTYMust { get; set; }
        public decimal QTYFromStock { get; set; }
        public decimal QTYToWork { get; set; }
        public int SOUTId { get; set; }
        public System.DateTime DatePostupleniya { get; set; }
        public bool Active { get; set; }
        public bool Stornirovano { get; set; }
    }
}
