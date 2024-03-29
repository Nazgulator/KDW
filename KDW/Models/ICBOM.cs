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
    
    public partial class ICBOM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ICBOM()
        {
            this.ICBOMChild = new HashSet<ICBOMChild>();
        }
    
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public string FBOMNumber { get; set; }
        public short FImpMode { get; set; }
        public Nullable<int> FUseStatus { get; set; }
        public string FVersion { get; set; }
        public Nullable<int> FParentID { get; set; }
        public int FItemID { get; set; }
        public decimal FQty { get; set; }
        public Nullable<decimal> FYield { get; set; }
        public Nullable<int> FCheckID { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public Nullable<int> FOperatorID { get; set; }
        public System.DateTime FEnterTime { get; set; }
        public short FStatus { get; set; }
        public bool FCancellation { get; set; }
        public int FTranType { get; set; }
        public int FRoutingID { get; set; }
        public int FBomType { get; set; }
        public int FCustID { get; set; }
        public int FCustItemID { get; set; }
        public int FAccessories { get; set; }
        public string FNote { get; set; }
        public int FUnitID { get; set; }
        public decimal FAUXQTY { get; set; }
        public Nullable<int> FCheckerID { get; set; }
        public Nullable<System.DateTime> FAudDate { get; set; }
        public int FEcnInterID { get; set; }
        public bool FBeenChecked { get; set; }
        public short FForbid { get; set; }
        public int FAuxPropID { get; set; }
        public Nullable<System.DateTime> FPDMImportDate { get; set; }
        public short FBOMSkip { get; set; }
        public Nullable<int> FClassTypeID { get; set; }
        public Nullable<int> FUserID { get; set; }
        public Nullable<System.DateTime> FUseDate { get; set; }
        public string FHeadSelfZ0135 { get; set; }
        public string FHeadSelfZ0136 { get; set; }
        public string FHeadSelfZ0137 { get; set; }
        public int FPrintCount { get; set; }
        public int FMultiCheckStatus { get; set; }
        public int FDeletedUse { get; set; }
        public int FIsECN { get; set; }
        public int FSendStatus { get; set; }
        public int FEnterpriseID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICBOMChild> ICBOMChild { get; set; }
    }
}
