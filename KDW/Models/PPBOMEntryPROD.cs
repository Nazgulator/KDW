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
    
    public partial class PPBOMEntryPROD
    {
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public int FEntryID { get; set; }
        public int FItemID { get; set; }
        public string FBatchNo { get; set; }
        public int FUnitID { get; set; }
        public decimal FQtyMust { get; set; }
        public decimal FAuxQtyMust { get; set; }
        public decimal FQty { get; set; }
        public decimal FAuxQty { get; set; }
        public string FMachinePos { get; set; }
        public string FSequenceID { get; set; }
        public Nullable<int> FStockID { get; set; }
        public string FNote { get; set; }
        public int FSourceEntryID { get; set; }
        public decimal FQtyScrap { get; set; }
        public decimal FAuxQtyScrap { get; set; }
        public decimal FScrap { get; set; }
        public Nullable<System.DateTime> FSendItemDate { get; set; }
        public decimal FQtyPick { get; set; }
        public decimal FAuxQtyPick { get; set; }
        public int FSPID { get; set; }
        public int FMaterielType { get; set; }
        public int FOperID { get; set; }
        public int FBackFlush { get; set; }
        public int FMarshalType { get; set; }
        public bool FStockType { get; set; }
        public decimal FQtyBackFlush { get; set; }
        public decimal FStockQty { get; set; }
        public decimal FAuxStockQty { get; set; }
        public Nullable<decimal> FAuxQtyLoss { get; set; }
        public Nullable<decimal> FQtyLoss { get; set; }
        public Nullable<decimal> FBOMInPutQTY { get; set; }
        public Nullable<decimal> FWIPQTY { get; set; }
        public Nullable<decimal> FWIPAuxQTY { get; set; }
        public short FLockFlag { get; set; }
        public decimal FSelDiscardQty { get; set; }
        public decimal FSelDiscardAuxQty { get; set; }
        public decimal FDiscardQty { get; set; }
        public decimal FDiscardAuxQty { get; set; }
        public decimal FBomInputAuxQty { get; set; }
        public int FICItemReplaceID { get; set; }
        public decimal FQtySupply { get; set; }
        public decimal FAuxQtySupply { get; set; }
        public int FOperSN { get; set; }
        public int FBomInterID { get; set; }
        public decimal FSelTransLateAuxQty { get; set; }
        public decimal FSelTransLateQty { get; set; }
        public decimal FTransLateAuxQty { get; set; }
        public decimal FTransLateQty { get; set; }
        public int FICMOInterID { get; set; }
        public int FChangeTimes { get; set; }
        public string FPositionNo { get; set; }
        public string FItemSize { get; set; }
        public string FItemSuite { get; set; }
        public string FNote1 { get; set; }
        public string FNote2 { get; set; }
        public string FNote3 { get; set; }
        public int FPlanMode { get; set; }
        public string FMTONo { get; set; }
        public int FOrderEntryID { get; set; }
        public decimal FQtyConsume { get; set; }
        public decimal FAuxQtyConsume { get; set; }
        public int FDetailID { get; set; }
        public int FItemConvertType { get; set; }
        public int FSubsBillEntryID { get; set; }
        public Nullable<System.Guid> FBomDetailID { get; set; }
        public int FICSubsID { get; set; }
        public int FICSubsEntryID { get; set; }
        public short FIsKeyItem { get; set; }
        public int FPriorityID { get; set; }
        public int FAuxPropID { get; set; }
        public int FOrderBOMInterID { get; set; }
        public int FOrderBOMEntryID { get; set; }
        public decimal FPlanQtyReq { get; set; }
        public decimal FPTLQty { get; set; }
        public decimal FSelDiscardStockInQty { get; set; }
        public decimal FSelDiscardStockInAuxQty { get; set; }
    
        public virtual PPBOMPROD PPBOMPROD { get; set; }
    }
}