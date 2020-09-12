﻿using Autofac;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Client.Models
{
    public class CartModel
    {
        IOrderService _orderService;
        public CartModel()
        {
            _orderService = Startup.AutofacContainer.Resolve<IOrderService>();
        }
        public CartModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public string MedImgUrl{get; set;}
        public string MedName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public NormalUser User { get; set; }
        public DateTime Orderdate { get; set; }
        
        public enum PaymentType
        {
            Cash,
            Card,
            cheque
        }
        public string PaymentTransactionID { get; set; }
        internal CartModel AddToCart(int id, int quantity)
        {
            Medicine medicine = _orderService.GetMedicine(id);
            var cart = new CartModel();
            cart.MedicineId = id;
            cart.MedName = medicine.Name;
            cart.MedImgUrl = medicine.Image.Url;
            cart.UnitPrice = medicine.Price;
            cart.Quantity = quantity;
            cart.TotalPrice = cart.UnitPrice * cart.Quantity;
            cart.Orderdate = DateTime.Now;

            return cart;
        }

        internal void AddOrder(NormalUser user, List<CartModel> list)
        {
            if (list != null)
            {
                _orderService.AddAnOrder(new Order
                {

                });
            }
        }
    }
}
