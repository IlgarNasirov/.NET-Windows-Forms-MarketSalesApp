using MarketSalesApp.Entities;
using MarketSalesApp.IRepository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.Repository
{
    public class LoginRepository: ILoginRepository
    {
        public int Login(Market_user market_User)
        {
            string query = "select id from [market_user] where username=@username and password=@password and isadmin=@isadmin";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@username",market_User.Username),
                new SqlParameter("@password",market_User.Password),
                new SqlParameter("@isadmin",market_User.Isadmin)
            };
            DbHelper dbHelper= new DbHelper();
            double result = dbHelper.ExecuteScalar(query, list);
            if (result > 0)
            {
                if (market_User.Isadmin)
                    return 1;
                    return 0;
            }
            return -1;
        }
    }
}
