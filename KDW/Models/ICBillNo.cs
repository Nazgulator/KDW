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
    
    public partial class ICBillNo
    {
        public int FBillID { get; set; }
        public string FBillName { get; set; }
        public string FPreLetter { get; set; }
        public string FSufLetter { get; set; }
        public Nullable<int> FCurNo { get; set; }
        public string FBillName_CHT { get; set; }
        public string FBillName_EN { get; set; }
        public string FFormat { get; set; }
        public Nullable<int> FPos { get; set; }
        public short FCanAlterBillNo { get; set; }
        public int FCheckAfterSave { get; set; }
        public int FUseBillCodeRule { get; set; }
        public string FDesc { get; set; }
        public byte FSingleApproval { get; set; }
        public byte FSingleUnApproval { get; set; }
        public byte FEditSelfBill { get; set; }
    }
}