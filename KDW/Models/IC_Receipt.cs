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
    
    public partial class IC_Receipt
    {
        public int FID { get; set; }
        public int FClassTypeID { get; set; }
        public string FBillNO { get; set; }
        public string FOrderID { get; set; }
        public Nullable<System.DateTime> FOrderDate { get; set; }
        public int FOrderFlag { get; set; }
        public int FTransactionStatus { get; set; }
        public long FUniqueCode { get; set; }
        public int FOrderType { get; set; }
        public string FWebshopID { get; set; }
        public string FBuyerMessage { get; set; }
        public string FBuyerNick { get; set; }
        public string FSellerMessage { get; set; }
        public decimal FTotalAmount { get; set; }
        public decimal FTotalDiscountFee { get; set; }
        public decimal FTotalFreight { get; set; }
        public decimal FFinallyAmount { get; set; }
        public Nullable<int> FLogisticsID { get; set; }
        public string FLogisticsOrder { get; set; }
        public decimal FReturnFreight { get; set; }
        public int FExchangeInStatus { get; set; }
        public int FRetrunInStatus { get; set; }
        public string FRetrunNote { get; set; }
        public Nullable<int> FSignatory { get; set; }
        public Nullable<System.DateTime> FReceiptDate { get; set; }
        public Nullable<int> FBiller { get; set; }
        public string FHelpCode { get; set; }
    }
}