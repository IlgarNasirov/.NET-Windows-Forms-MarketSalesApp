using MarketSalesApp.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.IRepository
{
    public interface ILoginRepository
    {
       int Login(Market_user market_User);
    }
}
