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
    
    public partial class ZPStockBillEntry
    {
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public int FEntryID { get; set; }
        public Nullable<int> FItemID { get; set; }
        public decimal FQty { get; set; }
        public string FBatchNo { get; set; }
        public string FNote { get; set; }
        public int FUnitID { get; set; }
        public decimal FAuxQty { get; set; }
        public int FSourceEntryID { get; set; }
        public decimal FCommitQty { get; set; }
        public decimal FAuxCommitQty { get; set; }
        public string FMapNumber { get; set; }
        public string FMapName { get; set; }
        public Nullable<System.DateTime> FKFDate { get; set; }
        public int FKFPeriod { get; set; }
        public Nullable<int> FDCSPID { get; set; }
        public int FAuxPropID { get; set; }
        public decimal FSecCoefficient { get; set; }
        public decimal FSecQty { get; set; }
        public decimal FSecCommitQty { get; set; }
        public int FSourceTranType { get; set; }
        public int FSourceInterId { get; set; }
        public string FSourceBillNo { get; set; }
        public int FDCStockID { get; set; }
        public Nullable<System.DateTime> FPeriodDate { get; set; }
        public int FPlanMode { get; set; }
        public string FMTONo { get; set; }
        public int FDetailID { get; set; }
        public int FSelectedProcID { get; set; }
    }
}