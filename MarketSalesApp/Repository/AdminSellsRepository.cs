using MarketSalesApp.IRepository;
using System.Data;

namespace MarketSalesApp.Repository
{
    public class AdminSellsRepository: IAdminSellsRepository
    {
        public DataTable AllAdminSell()
        {
            string sql = "select * from [sell]";
            DbHelper dbHelper = new DbHelper();
            return dbHelper.ExecuteReader(sql);
        }
    }
}
