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
    
    public partial class PlanLog
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public string WorkNumber { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public string Prichina { get; set; }
        public int UserId { get; set; }
        public string Zadanie { get; set; }
        public decimal QTYBilo { get; set; }
        public decimal QTYStalo { get; set; }
    }
}