using MarketSalesApp.Entities;
using MarketSalesApp.IRepository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.Repository
{
    public class AddProductRepository: IAddProductRepository
    {
        DbHelper dbHelper = new DbHelper();
        string sql;
        List<SqlParameter> list;
        public void AddProduct(Product product)
        {
            sql = "insert into [product] (name, quantity, price) values (@name, @quantity, @price)";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@name",product.Name),
                new SqlParameter("@quantity", product.Quantity),
                new SqlParameter("@price",product.Price)
            };
            dbHelper.ExecuteNonQuery(sql, list);
        }
        public void UpdateProduct(Product product, int id)
        {
            sql = "update [product] set name=@name, quantity=@quantity, price=@price where id=@id";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@name",product.Name),
                new SqlParameter("@quantity", product.Quantity),
                new SqlParameter("@price",product.Price),
                new SqlParameter("@id",id)
            };
            dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
