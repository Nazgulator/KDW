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
    
    public partial class ICMOChange
    {
        public int FID { get; set; }
        public int FClassTypeID { get; set; }
        public string FBillNo { get; set; }
        public int FBiller { get; set; }
        public Nullable<System.DateTime> FBillDate { get; set; }
        public Nullable<System.DateTime> FCheckDate { get; set; }
        public int FChecker { get; set; }
        public int FCheckFlag { get; set; }
    }
}
