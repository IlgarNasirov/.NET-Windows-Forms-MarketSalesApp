using System.Data;

namespace MarketSalesApp.IRepository
{
    public interface ISellerProductsRepository
    {
        DataTable AllSellerProduct();
    }
}
