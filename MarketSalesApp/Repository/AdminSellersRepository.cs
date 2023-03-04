using MarketSalesApp.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSalesApp.Repository
{
    public class AdminSellersRepository: IAdminSellersRepository
    {
        DbHelper dbHelper= new DbHelper();
        string sql;
        public DataTable AllAdminSeller()
        {
            sql = "select * from [market_user] where isadmin=0";
            return dbHelper.ExecuteReader(sql);
        }
        public void DeleteSeller(int id)
        {
            sql = "delete from [market_user] where id=@id";
            List<SqlParameter> list = new List<SqlParameter>() { new SqlParameter("@id", id) };
            dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
