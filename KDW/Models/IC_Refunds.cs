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
    
    public partial class IC_Refunds
    {
        public int fwebshopfid { get; set; }
        public string fwebshopid { get; set; }
        public string frefund_id { get; set; }
        public string ftid { get; set; }
        public string foid { get; set; }
        public Nullable<System.DateTime> fcreated { get; set; }
        public Nullable<System.DateTime> fmodified { get; set; }
        public string fbuyer_nick { get; set; }
        public string forder_status { get; set; }
        public string frefund_status { get; set; }
        public string fgood_status { get; set; }
        public Nullable<bool> fhas_good_return { get; set; }
        public Nullable<decimal> frefund_fee { get; set; }
        public Nullable<decimal> fpayment { get; set; }
        public string freason { get; set; }
        public string fdesc { get; set; }
        public string fnum_iid { get; set; }
        public string fouter_id { get; set; }
        public Nullable<decimal> fprice { get; set; }
        public Nullable<decimal> fnum { get; set; }
        public string fsid { get; set; }
        public string fcompany_name { get; set; }
        public string faddress { get; set; }
        public string frefund_phase { get; set; }
        public string frefund_version { get; set; }
    }
}