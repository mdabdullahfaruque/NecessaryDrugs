using NecessaryDrugs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetMedicines(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
        void AddANewMedicine(Medicine medicine);
        void AddMedicineCategory(int CateId, Medicine medicine);
        string GetCategoryListAsStringForAMedicine(IList<MedicineCategory> medicineCategories);
        IEnumerable<Category> GetCategoryListForAMedicine(IList<MedicineCategory> medicineCategories);
        IEnumerable<Category> GetAllCategories();
        Medicine GetMedicine(int id);
        void SaveInDbContext();
        void DeleteMedicine(int id);
        void EditMedicine(Medicine medicine);
        string GetDiscountAsString(Discount priceDiscount);
    }
}
