using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NecessaryDrugs.Web.Areas.Admin.Models;

namespace NecessaryDrugs.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewCaregory();
            }
            return View();
        }
    }
}
