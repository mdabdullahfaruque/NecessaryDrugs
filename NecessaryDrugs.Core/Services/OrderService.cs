using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public class OrderService : IOrderService
    {
        private IMedicineStoreUnitOfWork _medicineStoreUnitOfWork;
        public OrderService(IMedicineStoreUnitOfWork medicineStoreUnitOfWork)
        {
            _medicineStoreUnitOfWork = medicineStoreUnitOfWork;
        }

        public void AddAnOrder(Order order)
        {
            _medicineStoreUnitOfWork.OrderRepository.Add(order);
            _medicineStoreUnitOfWork.Save();
        }

        public void DeleteOrder(int id)
        {
            _medicineStoreUnitOfWork.OrderRepository.Remove(id);
            _medicineStoreUnitOfWork.Save();
        }

        public IList<Order> GetAllOrders()
        {
            return _medicineStoreUnitOfWork.OrderRepository.Get(null, y => y.OrderBy("Orderdate"), "OrderedMedicines", true);
        }

        public object GetAllStocks()
        {
            throw new NotImplementedException();
        }

        public int GetAvailableQuantity(int id)
        {
            var medicine = _medicineStoreUnitOfWork.MedicineRepository.GetByIdWithIncludeProperty(x => x.Id.Equals(id), "Stock");
            var medicineStock=_medicineStoreUnitOfWork.StockRepository.GetById(medicine.Stock.Id);
            return medicineStock.Quantity;
        }

        public Medicine GetMedicine(int id)
        {
            return _medicineStoreUnitOfWork.MedicineRepository.GetByIdWithIncludeProperty(x => x.Id == id, "Categories,PriceDiscount,Image");
        }

        public void UpdateMedicineStock(int medicineId, int quantity)
        {
            var medicine = _medicineStoreUnitOfWork.MedicineRepository.GetByIdWithIncludeProperty(x=>x.Id==medicineId,"Stock");
            var medicineStock = _medicineStoreUnitOfWork.StockRepository.GetById(medicine.Stock.Id);
            medicineStock.Quantity -= quantity;
            _medicineStoreUnitOfWork.Save();
        }
    }
}
