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
    
    public partial class t_Fee
    {
        public int FItemID { get; set; }
        public string FName { get; set; }
        public string FBrNO { get; set; }
        public Nullable<int> FFeeType { get; set; }
        public string FUnit { get; set; }
        public string FNumber { get; set; }
        public Nullable<int> FParentID { get; set; }
        public short FDeleted { get; set; }
        public string FShortNumber { get; set; }
        public string FRemark { get; set; }
        public byte[] FModifyTime { get; set; }
    }
}