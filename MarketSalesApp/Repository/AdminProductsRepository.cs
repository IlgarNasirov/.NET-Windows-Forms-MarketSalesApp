using MarketSalesApp.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MarketSalesApp.Repository
{
    public class AdminProductsRepository: IAdminProductsRepository
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        public DataTable AllAdminProduct()
        {
            sql = "select * from [product]";
            return dbHelper.ExecuteReader(sql);
        }
        public void DeleteProduct(int id)
        {
            sql = "delete from [product] where id=@id";
            List<SqlParameter> list = new List<SqlParameter>() { new SqlParameter("@id", id) };
            dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
