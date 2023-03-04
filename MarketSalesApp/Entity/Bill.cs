

using System;

namespace MarketSalesApp.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Billdate { get; set; }
        public double Totalamount { get; set; }
    }
}
