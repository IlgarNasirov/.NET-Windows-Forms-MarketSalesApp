using MarketSalesApp.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.IRepository
{
    public interface IAddSellerRepository
    {
        void AddSeller(Market_user market_User);
        void UpdateSeller(Market_user market_User, int id);
    }
}
