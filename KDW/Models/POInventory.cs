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
    
    public partial class POInventory
    {
        public string FBrNo { get; set; }
        public int FItemID { get; set; }
        public string FBatchNo { get; set; }
        public int FStockID { get; set; }
        public decimal FQty { get; set; }
        public decimal FBal { get; set; }
        public int FStockPlaceID { get; set; }
        public int FKFPeriod { get; set; }
        public string FKFDate { get; set; }
        public int FStockTypeID { get; set; }
        public int FAuxPropID { get; set; }
        public decimal FSecQty { get; set; }
        public string FMTONo { get; set; }
        public int FSupplyID { get; set; }
    }
}