using Autofac;
using Autofac.Extensions.DependencyInjection;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.Services;
using NecessaryDrugs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class CategoryUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICategoryService _categoryService;
        public CategoryUpdateModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }
        public CategoryUpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        

        internal void AddNewCaregory()
        {
            try
            {

                _categoryService.AddANewCategory(new Category
                {
                    Name = this.Name
                });
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
            catch (Exception ex)
            {
                Notification = new NotificationModel("Failed!",
                    "Failed to add category, please try again.",
                    Notificationtype.Fail);
            }

        }
    }
}
