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
    
    public partial class ICMOPROD
    {
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public string FBillNo { get; set; }
        public short FTranType { get; set; }
        public short FStatus { get; set; }
        public short FMRP { get; set; }
        public Nullable<short> FType { get; set; }
        public Nullable<int> FWorkShop { get; set; }
        public int FItemID { get; set; }
        public decimal FQty { get; set; }
        public decimal FCommitQty { get; set; }
        public Nullable<System.DateTime> FPlanCommitDate { get; set; }
        public Nullable<System.DateTime> FPlanFinishDate { get; set; }
        public Nullable<int> FConveyerID { get; set; }
        public Nullable<System.DateTime> FCommitDate { get; set; }
        public Nullable<int> FCheckerID { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public Nullable<int> FRequesterID { get; set; }
        public Nullable<int> FBillerID { get; set; }
        public short FSourceEntryID { get; set; }
        public short FClosed { get; set; }
        public string FNote { get; set; }
        public int FUnitID { get; set; }
        public decimal FAuxCommitQty { get; set; }
        public decimal FAuxQty { get; set; }
        public Nullable<int> FOrderInterID { get; set; }
        public Nullable<int> FPPOrderInterID { get; set; }
        public Nullable<int> FParentInterID { get; set; }
        public bool FCancellation { get; set; }
        public Nullable<int> FSupplyID { get; set; }
        public decimal FQtyFinish { get; set; }
        public decimal FQtyScrap { get; set; }
        public Nullable<decimal> FQtyForItem { get; set; }
        public decimal FQtyLost { get; set; }
        public Nullable<System.DateTime> FPlanIssueDate { get; set; }
        public Nullable<int> FRoutingID { get; set; }
        public Nullable<System.DateTime> FStartDate { get; set; }
        public Nullable<System.DateTime> FFinishDate { get; set; }
        public decimal FAuxQtyFinish { get; set; }
        public decimal FAuxQtyScrap { get; set; }
        public Nullable<decimal> FAuxQtyForItem { get; set; }
        public decimal FAuxQtyLost { get; set; }
        public int FMrpClosed { get; set; }
        public int FBomInterID { get; set; }
        public decimal FQtyPass { get; set; }
        public decimal FAuxQtyPass { get; set; }
        public decimal FQtyBack { get; set; }
        public decimal FAuxQtyBack { get; set; }
        public decimal FFinishTime { get; set; }
        public decimal FReadyTIme { get; set; }
        public decimal FPowerCutTime { get; set; }
        public decimal FFixTime { get; set; }
        public decimal FWaitItemTime { get; set; }
        public decimal FWaitToolTime { get; set; }
        public int FTaskID { get; set; }
        public int FWorkTypeID { get; set; }
        public int FCostObjID { get; set; }
        public decimal FStockQty { get; set; }
        public decimal FAuxStockQty { get; set; }
        public bool FSuspend { get; set; }
        public Nullable<int> FProjectNO { get; set; }
        public Nullable<int> FProductionLineID { get; set; }
        public decimal FReleasedQty { get; set; }
        public decimal FReleasedAuxQty { get; set; }
        public decimal FUnScheduledQty { get; set; }
        public decimal FUnScheduledAuxQty { get; set; }
        public int FSubEntryID { get; set; }
        public int FScheduleID { get; set; }
        public int FPlanOrderInterID { get; set; }
        public decimal FProcessPrice { get; set; }
        public decimal FProcessFee { get; set; }
        public string FGMPBatchNo { get; set; }
        public decimal FGMPCollectRate { get; set; }
        public decimal FGMPItemBalance { get; set; }
        public decimal FGMPBulkQty { get; set; }
        public int FCustID { get; set; }
        public Nullable<int> FMultiCheckLevel1 { get; set; }
        public Nullable<int> FMultiCheckLevel2 { get; set; }
        public Nullable<int> FMultiCheckLevel3 { get; set; }
        public Nullable<int> FMultiCheckLevel4 { get; set; }
        public Nullable<int> FMultiCheckLevel5 { get; set; }
        public Nullable<int> FMultiCheckLevel6 { get; set; }
        public Nullable<System.DateTime> FMultiCheckDate1 { get; set; }
        public Nullable<System.DateTime> FMultiCheckDate2 { get; set; }
        public Nullable<System.DateTime> FMultiCheckDate3 { get; set; }
        public Nullable<System.DateTime> FMultiCheckDate4 { get; set; }
        public Nullable<System.DateTime> FMultiCheckDate5 { get; set; }
        public Nullable<System.DateTime> FMultiCheckDate6 { get; set; }
        public Nullable<int> FCurCheckLevel { get; set; }
        public int FMRPLockFlag { get; set; }
        public int FHandworkClose { get; set; }
        public Nullable<int> FConfirmerID { get; set; }
        public Nullable<System.DateTime> FConfirmDate { get; set; }
        public decimal FInHighLimit { get; set; }
        public decimal FInHighLimitQty { get; set; }
        public decimal FAuxInHighLimitQty { get; set; }
        public decimal FInLowLimit { get; set; }
        public decimal FInLowLimitQty { get; set; }
        public decimal FAuxInLowLimitQty { get; set; }
        public int FChangeTimes { get; set; }
        public decimal FCheckCommitQty { get; set; }
        public decimal FAuxCheckCommitQty { get; set; }
        public Nullable<System.DateTime> FCloseDate { get; set; }
        public int FPlanConfirmed { get; set; }
        public int FPlanMode { get; set; }
        public string FMTONo { get; set; }
        public int FPrintCount { get; set; }
        public int FFinClosed { get; set; }
        public Nullable<int> FFinCloseer { get; set; }
        public Nullable<System.DateTime> FFinClosedate { get; set; }
        public int FStockFlag { get; set; }
        public int FStartFlag { get; set; }
        public string FVchBillNo { get; set; }
        public int FVchInterID { get; set; }
        public int FCardClosed { get; set; }
        public decimal FHRReadyTime { get; set; }
        public int FPlanCategory { get; set; }
        public int FBomCategory { get; set; }
        public int FSourceTranType { get; set; }
        public int FSourceInterId { get; set; }
        public string FSourceBillNo { get; set; }
        public decimal FReprocessedAuxQty { get; set; }
        public decimal FReprocessedQty { get; set; }
        public decimal FSelDiscardStockInAuxQty { get; set; }
        public decimal FSelDiscardStockInQty { get; set; }
        public decimal FDiscardStockInAuxQty { get; set; }
        public decimal FDiscardStockInQty { get; set; }
        public decimal FSampleBreakAuxQty { get; set; }
        public decimal FSampleBreakQty { get; set; }
        public long FResourceID { get; set; }
        public int FAddInterID { get; set; }
        public string FAPSImported { get; set; }
        public int FAPSLastStatus { get; set; }
        public int FAuxPropID { get; set; }
        public int FOrderBOMEntryID { get; set; }
        public Nullable<System.DateTime> FStartTimePDA { get; set; }
        public bool FIsMakeLowerBill { get; set; }
        public int FFlowCardStatus { get; set; }
        public Nullable<int> FIsMesStartWork { get; set; }
    }
}
