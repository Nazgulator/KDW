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
    
    public partial class PPOrder
    {
        public string FBrNo { get; set; }
        public int FInterID { get; set; }
        public string FBillNo { get; set; }
        public int FTranType { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public Nullable<int> FBillerID { get; set; }
        public Nullable<int> FCheckerID { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public short FStatus { get; set; }
        public Nullable<int> FPlanType { get; set; }
        public Nullable<int> FParentInterID { get; set; }
        public Nullable<int> FOrderInterID { get; set; }
        public bool FCancellation { get; set; }
        public short FMrpClosed { get; set; }
        public Nullable<int> FCurCheckLevel { get; set; }
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
        public int FSelTranType { get; set; }
        public int FPlanCategory { get; set; }
        public int FPrintCount { get; set; }
    }
}