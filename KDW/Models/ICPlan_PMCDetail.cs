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
    
    public partial class ICPlan_PMCDetail
    {
        public int FIndex { get; set; }
        public int FRunID { get; set; }
        public int FRunIndex { get; set; }
        public int FItemID { get; set; }
        public int FUnitID { get; set; }
        public Nullable<System.DateTime> FNeedDate { get; set; }
        public int FDayID { get; set; }
        public int FBOMLevel { get; set; }
        public int FSrcTranType { get; set; }
        public int FSrcInterID { get; set; }
        public int FSrcEntryID { get; set; }
        public int FRelTranType { get; set; }
        public int FRelInterID { get; set; }
        public int FRelEntryID { get; set; }
        public int FParentTranType { get; set; }
        public int FParentInterID { get; set; }
        public int FParentEntryID { get; set; }
        public decimal FNeedQty { get; set; }
        public decimal FStockQty { get; set; }
        public decimal FWillOutQty { get; set; }
        public decimal FWillInQty { get; set; }
        public decimal FBillLockQty { get; set; }
        public int FPlanOrderInterID { get; set; }
        public int FDestBillTranType { get; set; }
        public int FDestBillInterID { get; set; }
        public int FDestBillEntryID { get; set; }
        public int FBOMCategory { get; set; }
        public int FBomInterID { get; set; }
        public int FOrderBOMInterID { get; set; }
        public Nullable<short> FBOMSkip { get; set; }
        public int FBillType { get; set; }
        public int FISOldData { get; set; }
        public int FCalOrder { get; set; }
        public int FAdjustID { get; set; }
        public Nullable<System.DateTime> FRelationOrgNeedDate { get; set; }
        public string FNote { get; set; }
        public int FAuxPropID { get; set; }
        public int FPlanCategory { get; set; }
        public int FPlanMode { get; set; }
        public string FMtoNo { get; set; }
        public Nullable<int> FOrderBomEntryID { get; set; }
        public Nullable<decimal> FScrap { get; set; }
    
        public virtual ICMO ICMO { get; set; }
    }
}