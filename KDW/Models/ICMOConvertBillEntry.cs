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
    
    public partial class ICMOConvertBillEntry
    {
        public int FEntryID { get; set; }
        public int FID { get; set; }
        public int FIndex { get; set; }
        public int FOldWBInterID { get; set; }
        public int FOldOperID { get; set; }
        public decimal FAuxNewOperPlanQty { get; set; }
        public decimal FNewOperPlanQty { get; set; }
        public int FNewItemID { get; set; }
        public int FnewCostID { get; set; }
        public int FNewUnitID { get; set; }
        public int FNewType { get; set; }
        public int FNewWorkShop { get; set; }
        public int FNewSupplyID { get; set; }
        public int FNewBOMInterID { get; set; }
        public int FNewRoutingID { get; set; }
        public Nullable<System.DateTime> FNewPlanCommitDate { get; set; }
        public Nullable<System.DateTime> FNewPlanFinishDate { get; set; }
        public int FNewFirstOperSN { get; set; }
        public int FNewWBInterID { get; set; }
        public string FNewWBBillNo { get; set; }
        public decimal FAuxConvertQty { get; set; }
        public string FNewBatchNo { get; set; }
        public string FConvertReason { get; set; }
        public int FConverterID { get; set; }
        public Nullable<System.DateTime> FConvertDate { get; set; }
        public string FConvertFlag { get; set; }
        public string FNote { get; set; }
        public decimal FConvertQty { get; set; }
        public int FOldOperSN { get; set; }
        public int FNewWorkTypeID { get; set; }
        public int FNewFirstOperID { get; set; }
        public string FOldWBBillNo { get; set; }
        public int FNewBaseUnitID { get; set; }
        public int FCustID { get; set; }
        public int FTraceTypeID { get; set; }
        public int FNewAuxPropID { get; set; }
        public int FBOMCategory { get; set; }
    }
}
