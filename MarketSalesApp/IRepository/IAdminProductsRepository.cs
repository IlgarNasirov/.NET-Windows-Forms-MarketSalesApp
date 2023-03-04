using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace MarketSalesApp.IRepository
{
    public interface IAdminProductsRepository
    {
        DataTable AllAdminProduct();
        void DeleteProduct(int id);
    }
}
