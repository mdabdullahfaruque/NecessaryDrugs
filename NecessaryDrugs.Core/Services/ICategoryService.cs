using NecessaryDrugs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public interface ICategoryService
    {
        void AddANewCategory(Category category);
        IEnumerable<Category> GetCategories(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
        Category GetCategoy(int id);
        void EditCategory(Category category);
        void DeleteCategory(int id);
    }
}
