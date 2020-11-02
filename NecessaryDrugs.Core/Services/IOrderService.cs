using NecessaryDrugs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public interface IOrderService
    {
        Medicine GetMedicine(int id);
        void AddAnOrder(Order order);
        object GetAllStocks();
        int GetAvailableQuantity(int id);
        void UpdateMedicineStock(int medicineId, int quantity);
        IList<Order> GetAllOrders();
        void DeleteOrder(int id);
    }
}
