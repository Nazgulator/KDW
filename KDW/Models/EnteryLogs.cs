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
    
    public partial class EnteryLogs
    {
        public int Id { get; set; }
        public string IPAdress { get; set; }
        public string Name { get; set; }
        public int WebUserId { get; set; }
        public string WebUserName { get; set; }
        public string KingDeeUserName { get; set; }
        public System.DateTime EnterDate { get; set; }
    }
}
