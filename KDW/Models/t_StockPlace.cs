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
    
    public partial class t_StockPlace
    {
        public int FSPID { get; set; }
        public int FSPGroupID { get; set; }
        public string FNumber { get; set; }
        public string FName { get; set; }
        public string FFullName { get; set; }
        public int FLevel { get; set; }
        public bool FDetail { get; set; }
        public int FParentID { get; set; }
        public string FFullNumber { get; set; }
        public string FShortNumber { get; set; }
        public string FDescription { get; set; }
        public short FDeleted { get; set; }
        public byte[] FModifyTime { get; set; }
        public Nullable<int> FSystemType { get; set; }
        public Nullable<System.Guid> UUID { get; set; }
        public int FClassTypeID { get; set; }
    
        public virtual t_StockPlaceGroup t_StockPlaceGroup { get; set; }
    }
}
