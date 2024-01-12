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
    
    public partial class ICSubContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ICSubContract()
        {
            this.Entries = new HashSet<ICSubContractEntry>();
        }
    
        public int FInterID { get; set; }
        public int FSupplyID { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public string FBillNo { get; set; }
        public int FInvStyle { get; set; }
        public int FSettleStyle { get; set; }
        public int FCurrencyID { get; set; }
        public int FDepartment { get; set; }
        public Nullable<System.DateTime> FSettleDate { get; set; }
        public double FExchangeRate { get; set; }
        public int FEmployee { get; set; }
        public int FMangerID { get; set; }
        public string FSummary { get; set; }
        public int FCheckerID { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public int FBillerID { get; set; }
        public byte FCancellation { get; set; }
        public byte FClosed { get; set; }
        public byte FStatus { get; set; }
        public byte FTranStatus { get; set; }
        public byte[] FModifyTime { get; set; }
        public int FClassTypeID { get; set; }
        public int FRelateBrID { get; set; }
        public int FBrID { get; set; }
        public string FPOOrdBillNo { get; set; }
        public byte FOrderRefuse { get; set; }
        public short FPrintCount { get; set; }
        public int FExchangeRateType { get; set; }
        public Nullable<System.DateTime> FClosedDate { get; set; }
        public int FPlanCategory { get; set; }
        public int FDeliveryPlace { get; set; }
        public int FAccessoryCount { get; set; }
        public int FCloserID { get; set; }
        public string FVersionNo { get; set; }
        public string FExeStatus { get; set; }
        public string FText { get; set; }
        public string FHeadSelfP0253 { get; set; }
        public short FConnectFlag { get; set; }
        public Nullable<int> FConcernStatus { get; set; }
        public int FSendStatus { get; set; }
        public int FEnterpriseID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICSubContractEntry> Entries { get; set; }
        public virtual t_Item Department { get; set; }
        public virtual t_Supplier Supplier { get; set; }
        public virtual t_Department t_Department { get; set; }
    }
}
