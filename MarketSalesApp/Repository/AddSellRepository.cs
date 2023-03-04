using MarketSalesApp.Entities;
using MarketSalesApp.IRepository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.Repository
{
    public class AddSellRepository: IAddSellRepository
    {
        DbHelper dbHelper = new DbHelper();
        string sql;
        List<SqlParameter> list;
        public void AddSell(Sell sell)
        {
            sql = "insert into [sell] (productname, quantity, total, price) values (@productname, @quantity, @total, @price)";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@productname",sell.Productname),
                new SqlParameter("@quantity", sell.Quantity),
                new SqlParameter("@total", sell.Total),
                new SqlParameter("@price",sell.Price)
            };
            dbHelper.ExecuteNonQuery(sql, list);
        }
        public void UpdateSell(Sell sell, int id)
        {
            sql = "update [sell] set productname=@productname, quantity=@quantity, total=@total, price=@price where id=@id";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@productname",sell.Productname),
                new SqlParameter("@quantity", sell.Quantity),
                new SqlParameter("@total", sell.Total),
                new SqlParameter("@price",sell.Price),
                new SqlParameter("@id",id)
            };
            dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
