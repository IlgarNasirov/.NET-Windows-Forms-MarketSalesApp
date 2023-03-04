using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using MarketSalesApp.IRepository;

namespace MarketSalesApp.Repository
{
    public class SellerSellsRepository: ISellerSellsRepository
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        List<SqlParameter> list;
        public DataTable AllSellerSell()
        {
            sql = "select * from [sell]";
            return dbHelper.ExecuteReader(sql);
        }
        public void DeleteSell(int id)
        {
            sql = "delete from [sell] where id=@id";
            list = new List<SqlParameter>() { new SqlParameter("@id", id) };
            dbHelper.ExecuteNonQuery(sql, list);
        }
        public int SellToBill(string userName)
        {
            sql = "select * from [sell] where status=0";
            double value=0;

            foreach (DataRow row in dbHelper.ExecuteReader(sql).Rows)
            {
                value += Convert.ToDouble(row.ItemArray[4]);
            }
            sql = "insert into [bill] (username, billdate, totalamount) values (@username, @billdate, @totalamount)";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@username",userName),
                new SqlParameter("@billdate",DateTime.Now.ToString("MM/dd/yyyy")),
                new SqlParameter("@totalamount",value)
            };
            dbHelper.ExecuteNonQuery(sql, list);
            sql = "update [sell] set status=@status where status=0";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@status",1)
            };
            int result=dbHelper.ExecuteNonQuery(sql, list);
            return result;
        }
    }
}
