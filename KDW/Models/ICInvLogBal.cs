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
    
    public partial class ICInvLogBal
    {
        public string FBrNo { get; set; }
        public int FYear { get; set; }
        public short FPeriod { get; set; }
        public int FSupplyID { get; set; }
        public int FItemID { get; set; }
        public string FBatchNo { get; set; }
        public Nullable<decimal> FBegQty { get; set; }
        public Nullable<decimal> FRecQty { get; set; }
        public Nullable<decimal> FSenQty { get; set; }
        public Nullable<decimal> FPaidQty { get; set; }
        public Nullable<decimal> FYtdRecAmount { get; set; }
        public Nullable<decimal> FYtdSenAmount { get; set; }
        public Nullable<decimal> FYtdPaidAmount { get; set; }
        public Nullable<decimal> FEndQty { get; set; }
        public Nullable<decimal> FBegAmount { get; set; }
        public Nullable<decimal> FRecAmount { get; set; }
        public Nullable<decimal> FSenAmount { get; set; }
        public Nullable<decimal> FPaidAmount { get; set; }
        public Nullable<decimal> FEndAmount { get; set; }
        public Nullable<decimal> FActCost { get; set; }
        public Nullable<decimal> FPlanCost { get; set; }
        public Nullable<decimal> FReceiveDiff { get; set; }
    }
}