using Autofac;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using NecessaryDrugs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class MedicineViewModel
    {
        private IMedicineService _medicineService;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public IList<MedicineImage> Images { get; set; }
        public Discount PriceDiscount { get; set; }
        public MedicineViewModel()
        {
            _medicineService = Startup.AutofacContainer.Resolve<IMedicineService>();
        }
        public MedicineViewModel(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        public object GetMedicines(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _medicineService.GetMedicines(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);
            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Image.Url,
                            record.Name,
                            record.Description,
                            _medicineService.GetCategoryListAsStringForAMedicine(record.Categories),
                            record.Price.ToString(),
                            _medicineService.GetDiscountAsString(record.PriceDiscount),
                            //record.PriceDiscount.GetType().Name,
                            //record.PriceDiscount.Amount.ToString(),
                            record.Id.ToString()
                        }
                    ).ToList()
            };
        }
    }
}
