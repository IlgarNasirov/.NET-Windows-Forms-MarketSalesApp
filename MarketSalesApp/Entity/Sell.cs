

namespace MarketSalesApp.Entities
{
    public class Sell
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Total { get; set; }
        public bool Status { get; set; }
    }
}
