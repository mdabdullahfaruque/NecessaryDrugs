using Autofac;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class StockUpdateModel : BaseModel
    {
        IStockService _stockService;
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Medicine Id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double TotalPrice { get; set; }
        public string Description { get; set; }
        public StockUpdateModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public StockUpdateModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        internal void Load(int id)
        {
            var stock = _stockService.GetStock(id);
            if (stock != null)
            {
                Id = stock.Id;
                MedicineId = stock.MedicineId;
                Quantity = stock.Quantity;
                TotalPrice = stock.TotalPrice;
                Description = stock.Description;
            }
        }

        internal void AddStock()
        {
            try
            {

                _stockService.AddANewStock(new Stock
                {
                    MedicineId = this.MedicineId,
                    Quantity=Quantity,
                    TotalPrice=TotalPrice,
                    Description=Description
                });
                Notification = new NotificationModel("Success!",
                    "Stock added successfully.",
                    Notificationtype.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel("Failed!",
                    "Failed to add Stock, please provide valid name.",
                    Notificationtype.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel("Failed!",
                    "Failed to add Stock, please try again.",
                    Notificationtype.Fail);
            }
        }

        internal void Delete(int id)
        {
            _stockService.DeleteStock(id);
        }

        internal void UpdateStock(int id)
        {
            try
            {

                _stockService.EditStock(new Stock
                {
                    Id=Id,
                    MedicineId = this.MedicineId,
                    Quantity = Quantity,
                    TotalPrice = TotalPrice,
                    Description = Description
                });
                Notification = new NotificationModel("Success!",
                    "Stock added successfully.",
                    Notificationtype.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel("Failed!",
                    "Failed to add Stock, please provide valid name.",
                    Notificationtype.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel("Failed!",
                    "Failed to add Stock, please try again.",
                    Notificationtype.Fail);
            }
        }

        public IEnumerable<StockViewModel> GetAllStocks()
        {
            var allData = _stockService.GetAllStocks();
            var StockModelList = new List<StockViewModel>();
            foreach (var Stock in allData)
            {
                StockModelList.Add(new StockViewModel
                {
                    Id = Stock.Id,
                    MedicineId = Stock.MedicineId,
                    Quantity = Stock.Quantity,
                    TotalPrice = Stock.TotalPrice,
                    Description = Stock.Description
                });
            }
            return StockModelList;
        }
    }
}
