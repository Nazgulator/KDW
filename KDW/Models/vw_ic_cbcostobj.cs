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
    
    public partial class vw_ic_cbcostobj
    {
        public string FModel { get; set; }
        public int FItemID { get; set; }
        public string FNumber { get; set; }
        public string FName { get; set; }
        public int FStdID { get; set; }
        public int FStdSubID { get; set; }
        public Nullable<int> FParentID { get; set; }
        public string FShortNumber { get; set; }
        public bool FUnUsed { get; set; }
        public short FCalculateType { get; set; }
        public int FStdProductID { get; set; }
        public string FBatchNo { get; set; }
        public int FBomID { get; set; }
        public byte FEditable { get; set; }
        public string FSBillNo { get; set; }
        public byte[] FModifyTime { get; set; }
        public short FDeleted { get; set; }
    }
}
