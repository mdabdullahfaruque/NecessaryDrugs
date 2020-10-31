using Autofac;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using NecessaryDrugs.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Client.Models
{
    public class MedicineViewModel : BaseModel
    {
        private IMedicineService _medicineService;

        public MedicineViewModel()
        {
            _medicineService = Startup.AutofacContainer.Resolve<IMedicineService>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public IList<MedicineImage> Images { get; set; }
        public Discount PriceDiscount { get; set; }

        internal IEnumerable<MedicineViewModel> GetMedicines()
        {
            var allData = _medicineService.GetAllMedicine();
            var medicineModelList = new List<MedicineViewModel>();
            foreach (var medicine in allData)
            {
                var med=_medicineService.GetMedicine(medicine.Id);
                medicineModelList.Add(new MedicineViewModel
                {
                    Id = med.Id,
                    Name = med.Name,
                    GenericName = med.GenericName,
                    Url =med.Image.Url,
                    Price = med.Price,
                });
            }
            return medicineModelList;
        }

        internal IEnumerable<MedicineViewModel> GetFilteredMedicines(string searchString)
        {
            var allData = _medicineService.GetFilteredMedicine(searchString);
            var medicineModelList = new List<MedicineViewModel>();
            foreach (var medicine in allData)
            {
                var med = _medicineService.GetMedicine(medicine.Id);
                medicineModelList.Add(new MedicineViewModel
                {
                    Id = med.Id,
                    Name = med.Name,
                    GenericName = med.GenericName,
                    Url = med.Image.Url,
                    Price = med.Price,
                });
            }
            return medicineModelList;
        }

        internal MedicineViewModel GetDetails(int id)
        {
            var medicine = _medicineService.GetMedicine(id);
            Id = medicine.Id;
            Name = medicine.Name;
            GenericName = medicine.GenericName;
            Url = medicine.Image.Url;
            Description = medicine.Description;
            Price = medicine.Price;
            return this;
        }
    }
}
