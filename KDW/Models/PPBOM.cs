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
    
    public partial class PPBOM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PPBOM()
        {
            this.PPBOMEntry = new HashSet<PPBOMEntry>();
        }
    
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public string FBillNo { get; set; }
        public int FTranType { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public Nullable<int> FBillerID { get; set; }
        public Nullable<int> FCheckerID { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public short FStatus { get; set; }
        public Nullable<int> FICMOInterID { get; set; }
        public bool FCancellation { get; set; }
        public int FItemID { get; set; }
        public int FUnitID { get; set; }
        public decimal FAuxQty { get; set; }
        public Nullable<int> FType { get; set; }
        public short FStockType { get; set; }
        public Nullable<int> FWorkSHop { get; set; }
        public int FOrderInterID { get; set; }
        public string FOrderBillNo { get; set; }
        public int FChangeTimes { get; set; }
        public int FOrderEntryID { get; set; }
        public int FPrintCount { get; set; }
        public int FSelTranType { get; set; }
        public int FAuxPropID { get; set; }
        public int FMultiCheckStatus { get; set; }
        public string FICMOBillNo { get; set; }
        public string FHeadSelfY0227 { get; set; }
    
        public virtual ICMO ICMO { get; set; }
        public virtual t_Item t_Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PPBOMEntry> PPBOMEntry { get; set; }
    }
}
