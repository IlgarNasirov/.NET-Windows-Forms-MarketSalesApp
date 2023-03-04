using MarketSalesApp.IRepository;
using System.Data;

namespace MarketSalesApp.Repository
{
    public class SellerBillsRepository: ISellerBillsRepository
    {
        public DataTable AllSellerBill()
        {
            string sql = "select * from [bill]";
            DbHelper dbHelper = new DbHelper();
            return dbHelper.ExecuteReader(sql);
        }
    }
}
