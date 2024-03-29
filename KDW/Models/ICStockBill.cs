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
    
    public partial class ICStockBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ICStockBill()
        {
            this.ICStockBillEntry = new HashSet<ICStockBillEntry>();
            this.DvigenieNEW = new HashSet<DvigenieNEW>();
            this.DvigenieNEW1 = new HashSet<DvigenieNEW>();
        }
    
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public Nullable<short> FTranType { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public string FBillNo { get; set; }
        public string FUse { get; set; }
        public string FNote { get; set; }
        public Nullable<int> FDCStockID { get; set; }
        public Nullable<int> FSCStockID { get; set; }
        public Nullable<int> FDeptID { get; set; }
        public Nullable<int> FEmpID { get; set; }
        public Nullable<int> FSupplyID { get; set; }
        public Nullable<int> FPosterID { get; set; }
        public Nullable<int> FCheckerID { get; set; }
        public Nullable<int> FFManagerID { get; set; }
        public Nullable<int> FSManagerID { get; set; }
        public Nullable<int> FBillerID { get; set; }
        public Nullable<int> FReturnBillInterID { get; set; }
        public string FSCBillNo { get; set; }
        public Nullable<int> FHookInterID { get; set; }
        public Nullable<int> FVchInterID { get; set; }
        public short FPosted { get; set; }
        public Nullable<short> FCheckSelect { get; set; }
        public Nullable<int> FCurrencyID { get; set; }
        public Nullable<int> FSaleStyle { get; set; }
        public Nullable<int> FAcctID { get; set; }
        public short FROB { get; set; }
        public string FRSCBillNo { get; set; }
        public short FStatus { get; set; }
        public bool FUpStockWhenSave { get; set; }
        public bool FCancellation { get; set; }
        public int FOrgBillInterID { get; set; }
        public Nullable<int> FBillTypeID { get; set; }
        public Nullable<int> FPOStyle { get; set; }
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
        public Nullable<int> FTaskID { get; set; }
        public Nullable<int> FResourceID { get; set; }
        public bool FBackFlushed { get; set; }
        public int FWBInterID { get; set; }
        public int FTranStatus { get; set; }
        public Nullable<int> FZPBillInterID { get; set; }
        public Nullable<int> FRelateBrID { get; set; }
        public int FPurposeID { get; set; }
        public System.Guid FUUID { get; set; }
        public int FRelateInvoiceID { get; set; }
        public byte[] FOperDate { get; set; }
        public Nullable<int> FImport { get; set; }
        public Nullable<int> FSystemType { get; set; }
        public int FMarketingStyle { get; set; }
        public int FPayBillID { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public string FExplanation { get; set; }
        public string FFetchAdd { get; set; }
        public Nullable<System.DateTime> FFetchDate { get; set; }
        public int FManagerID { get; set; }
        public int FRefType { get; set; }
        public int FSelTranType { get; set; }
        public int FChildren { get; set; }
        public short FHookStatus { get; set; }
        public int FActPriceVchTplID { get; set; }
        public int FPlanPriceVchTplID { get; set; }
        public int FProcID { get; set; }
        public int FActualVchTplID { get; set; }
        public int FPlanVchTplID { get; set; }
        public Nullable<int> FBrID { get; set; }
        public int FVIPCardID { get; set; }
        public decimal FVIPScore { get; set; }
        public decimal FHolisticDiscountRate { get; set; }
        public string FPOSName { get; set; }
        public int FWorkShiftId { get; set; }
        public int FCussentAcctID { get; set; }
        public bool FZanGuCount { get; set; }
        public string FPOOrdBillNo { get; set; }
        public int FLSSrcInterID { get; set; }
        public Nullable<System.DateTime> FSettleDate { get; set; }
        public Nullable<int> FManageType { get; set; }
        public Nullable<int> FOrderAffirm { get; set; }
        public byte FAutoCreType { get; set; }
        public string FConsignee { get; set; }
        public int FDrpRelateTranType { get; set; }
        public short FPrintCount { get; set; }
        public Nullable<int> FPOMode { get; set; }
        public int FInventoryType { get; set; }
        public int FObjectItem { get; set; }
        public short FConfirmStatus { get; set; }
        public string FConfirmMem { get; set; }
        public Nullable<System.DateTime> FConfirmDate { get; set; }
        public int FConfirmer { get; set; }
        public int FAutoCreatePeriod { get; set; }
        public string FYearPeriod { get; set; }
        public Nullable<int> FPayCondition { get; set; }
        public Nullable<int> FsourceType { get; set; }
        public string FReceiver { get; set; }
        public Nullable<int> FHeadSelfB0154 { get; set; }
        public string FHeadSelfA0143 { get; set; }
        public string FHeadSelfB0435 { get; set; }
        public string FHeadSelfA0537 { get; set; }
        public string FHeadSelfB0836 { get; set; }
        public string FHeadSelfA9738 { get; set; }
        public string FHeadSelfB0939 { get; set; }
        public string FHeadSelfD0134 { get; set; }
        public string FHeadSelfC0131 { get; set; }
        public string FHeadSelfC0231 { get; set; }
        public string FHeadSelfA0230 { get; set; }
        public string FHeadSelfB0837 { get; set; }
        public Nullable<int> FHeadSelfB0436 { get; set; }
        public string FInvoiceStatus { get; set; }
        public int FSendStatus { get; set; }
        public int FEnterpriseID { get; set; }
        public Nullable<int> FBillReviewer { get; set; }
        public Nullable<System.DateTime> FBillReviewDate { get; set; }
        public string FCod { get; set; }
        public string FReceiveMan { get; set; }
        public string FConsigneeAdd { get; set; }
        public int FISUpLoad { get; set; }
        public string FReceiverMobile { get; set; }
        public int FAccessoryCount { get; set; }
        public string FHeadSelfA0233 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICStockBillEntry> ICStockBillEntry { get; set; }
        public virtual t_Department t_Department { get; set; }
        public virtual t_Supplier t_Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DvigenieNEW> DvigenieNEW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DvigenieNEW> DvigenieNEW1 { get; set; }
    }
}
