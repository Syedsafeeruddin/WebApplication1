//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int Payment_ID { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
        public Nullable<decimal> Cash_In { get; set; }
        public Nullable<decimal> Cash_Out { get; set; }
        public string Check_Voucher_In { get; set; }
        public string Check_Voucher_Out { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
