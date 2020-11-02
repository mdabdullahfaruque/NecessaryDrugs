using Autofac;
using Microsoft.AspNetCore.Identity;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string UserContact { get; set; }
        public string OrderItemsWithQuantity { get; set; }
        public string OrderStatus { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Orderdate { get; set; }

        IOrderService _orderService;
        UserManager<NormalUser> _userManager;

        public OrderModel()
        {
            _orderService = Startup.AutofacContainer.Resolve<IOrderService>();
            _userManager = Startup.AutofacContainer.Resolve<UserManager<NormalUser>>();
        }

        public OrderModel(IOrderService orderService, UserManager<NormalUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        internal async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            IList<Order> allOrders = _orderService.GetAllOrders();
            var modelList = new List<OrderModel>();
            foreach (var item in allOrders)
            {
                var user=await _userManager.FindByIdAsync(item.UserId);
                string orderItems=null;
                foreach (var med in item.OrderedMedicines)
                {
                    var medicine = _orderService.GetMedicine(med.MedicineId);
                    orderItems = ", "+medicine.Name + " * " + med.Quantity;
                }
                modelList.Add(new OrderModel
                {
                    OrderId = item.OrderId,
                    UserName = user.FirstName + " " + user.LastName,
                    UserContact = item.ContactNo,
                    OrderItemsWithQuantity = orderItems.TrimStart(',', ' '),
                    OrderStatus=item.DeliveryStatus,
                    Orderdate = item.Orderdate,
                    TotalPrice = item.TotalPrice
                }); ;
            }
            return modelList;
        }

        internal void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}
