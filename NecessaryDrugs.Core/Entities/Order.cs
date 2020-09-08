using NecessaryDrugs.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NecessaryDrugs.Core.Entities
{
    public class Order
    {
        public int OrderId {get; set;}
        public IList<Medicine> Medicines { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public NormalUser User { get; set; }
        public DateTime Orderdate { get; set; }
        public enum DeliveryStatus{ 
            pending,
            shipped,
            delivered
        }
        public DateTime DaliveryDate { get; set; }
        public enum PaymentType { 
            Cash,
            Card,
            cheque
        }
        public string PaymentTransactionID { get; set; }
    }
}
