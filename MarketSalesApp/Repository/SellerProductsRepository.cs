using MarketSalesApp.IRepository;
using System.Data;

namespace MarketSalesApp.Repository
{
    public class SellerProductsRepository: ISellerProductsRepository
    {
        public DataTable AllSellerProduct()
        {
            string sql = "select * from [product]";
            DbHelper dbHelper = new DbHelper();
            return dbHelper.ExecuteReader(sql);
        }

    }
}
