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
    
    public partial class InterfaceSelect
    {
        public int Id { get; set; }
        public string InterfaceName { get; set; }
        public bool Active { get; set; }
        public bool SkladPriemki { get; set; }
        public bool SkladBraka { get; set; }
        public bool SkladUchastka { get; set; }
        public bool SkladBrakaUchastka { get; set; }
        public bool SkladVozvrataNZP { get; set; }
        public bool SkladBuferZone { get; set; }
        public bool SkladPeremesheniyaBuferZone { get; set; }
    }
}
