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
    
    public partial class DocumentLog
    {
        public int Id { get; set; }
        public int DvigenieId { get; set; }
        public decimal QTY { get; set; }
        public string FBillNo { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int ToStock { get; set; }
        public int ToWork { get; set; }
        public string Opisanie { get; set; }
        public System.DateTime DateStart { get; set; }
    }
}
