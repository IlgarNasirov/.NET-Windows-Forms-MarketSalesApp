using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace MarketSalesApp.IRepository
{
    public interface IAdminSellersRepository
    {
        DataTable AllAdminSeller();
        void DeleteSeller(int id);
    }
}
