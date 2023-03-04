using MarketSalesApp.Entities;
using MarketSalesApp.IRepository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.Repository
{
    public class AddSellerRepository: IAddSellerRepository
    {
        DbHelper dbHelper = new DbHelper();
        string sql;
        List<SqlParameter> list;
        public void AddSeller(Market_user market_User)
        {
            sql = "insert into [market_User] (username, password) values (@username, @password)";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@username",market_User.Username),
                new SqlParameter("@password", market_User.Password)
            };
            dbHelper.ExecuteNonQuery(sql, list);
        }
        public void UpdateSeller(Market_user market_User, int id)
        {
            sql = "update [market_User] set username=@username, password=@password where id=@id";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@username",market_User.Username),
                new SqlParameter("@password", market_User.Password),
                new SqlParameter("@id",id)
            };
            dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
