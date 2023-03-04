using MarketSalesApp.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketSalesApp.IRepository
{
    public interface IAddProductRepository
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product, int id);
    }
}
