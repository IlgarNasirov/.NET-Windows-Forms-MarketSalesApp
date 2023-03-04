using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace MarketSalesApp.IRepository
{
    public interface ISellerSellsRepository
    {
        DataTable AllSellerSell();
        void DeleteSell(int id);
        int SellToBill(string userName);
    }
}
