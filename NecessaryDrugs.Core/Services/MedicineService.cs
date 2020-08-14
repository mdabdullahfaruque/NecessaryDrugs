using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public class MedicineService : IMedicineService
    {
        private IMedicineStoreUnitOfWork _medicineStoreUnitOfWork;
        public MedicineService(IMedicineStoreUnitOfWork medicineStoreUnitOfWork)
        {
            _medicineStoreUnitOfWork = medicineStoreUnitOfWork;
        }

        public void AddANewMedicine(Medicine medicine)
        {
            if (medicine == null || string.IsNullOrWhiteSpace(medicine.Name))
            {
                throw new InvalidOperationException("Medicine name is missing");
            }
            else
            {
                _medicineStoreUnitOfWork.MedicineRepository.Add(medicine);
                _medicineStoreUnitOfWork.Save();
            }
        }

        public void AddMedicineCategory(int CateId, Medicine medicine)
        {
            Category category = GetCategoryById(CateId);
            _medicineStoreUnitOfWork.MedicineCategoryRepository.Add(new MedicineCategory
            {
                CategoryId=CateId,
                Category=category,
                MedicineId=medicine.Id,
                Medicine=medicine
            });
            _medicineStoreUnitOfWork.Save();
        }
        public Category GetCategoryById(int catId)
        {
            return _medicineStoreUnitOfWork.CategoryRepository.GetById(catId);
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _medicineStoreUnitOfWork.CategoryRepository.GetAll(); ;
        }

        public IEnumerable<Medicine> GetMedicines(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _medicineStoreUnitOfWork.MedicineRepository.Get(
                out total, out totalFiltered, x => x.Name.Contains(searchText),
                null,
                "Categories,PriceDiscount,Image",
                pageIndex,
                pageSize,
                true
                );
        }

        public string GetCategoryListForAMedicine(IList<MedicineCategory> medicineCategories)
        {
            string allCategoryName="";
            foreach(MedicineCategory medicineCategory in medicineCategories)
            {
                var category=_medicineStoreUnitOfWork.CategoryRepository.GetById(medicineCategory.CategoryId);
                allCategoryName = allCategoryName +" , "+ category.Name;
            }
            return allCategoryName.TrimStart(' ',',');
        }
    }
}
