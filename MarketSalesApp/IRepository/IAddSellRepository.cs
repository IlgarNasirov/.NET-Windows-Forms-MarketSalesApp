using MarketSalesApp.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.IRepository
{
    public interface IAddSellRepository
    {
        void AddSell(Sell sell);
        void UpdateSell(Sell sell, int id);
    }
}
