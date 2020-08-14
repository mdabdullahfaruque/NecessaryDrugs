using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class MedicineUpdateModel : BaseModel
    {
        private IMedicineService _medicineService;
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string Category { get; set; }
        public IList<SelectListItem> Categories { get; set; }
        public IList<string> CategoriesId { get; set; }
        public Discount Discount { get; set; }
        internal IEnumerable<Category> GetAllCategory()
        {
            return _medicineService.GetAllCategories();
        }
        IList<MedicineCategory> SelectedCategories { get; set; }
        public MedicineImage Image2 { get; set; }

        public IFormFile Image { get; set; }
        public string DisountType { get; set; }
        public double AmountOrPercentage { get; set; }
        public string ReturnUrl { get; set; }
        public MedicineUpdateModel()
        {
            _medicineService = Startup.AutofacContainer.Resolve<IMedicineService>(); 
        }
        public MedicineUpdateModel(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        internal void AddNewMedicine(string url)
        {
            if (DisountType == "FixedAmountDiscount")
            {
                Discount = new FixedAmountDiscount { Amount = AmountOrPercentage };
            }
            else
            {
                Discount = new PercentageDiscount { Amount = AmountOrPercentage };
            }
            
            

            try
            {
                var medicine = new Medicine
                {
                    Name = Name,
                    Description = Description,
                    Image = new MedicineImage { Url = url },
                    Price = Price,
                    PriceDiscount = Discount
                };
                _medicineService.AddANewMedicine(medicine);
                foreach (string s in CategoriesId)
                {
                    int CatId = Convert.ToInt32(s);
                    _medicineService.AddMedicineCategory(CatId, medicine);
                }
                Notification = new NotificationModel("Success!",
                    "Category added successfully.",
                    Notificationtype.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel("Failed!",
                    "Failed to add category, please provide valid name.",
                    Notificationtype.Fail);
            }
        }

    }
}
