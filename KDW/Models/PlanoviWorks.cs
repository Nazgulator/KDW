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
    
    public partial class PlanoviWorks
    {
        public int Id { get; set; }
        public string WorkNumber { get; set; }
        public int WorkId { get; set; }
        public int Poryadok { get; set; }
        public decimal QTY { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual ICMO ICMO { get; set; }
    }
}