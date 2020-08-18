using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Web.Areas.Admin.Models;
using NecessaryDrugs.Web.Models;

namespace NecessaryDrugs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicineController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public MedicineController(IWebHostEnvironment env)
        {
            webHostEnvironment = env;
        }
        public IActionResult Index()
        {
            var model = new MedicineViewModel();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new MedicineUpdateModel();
            var Categories = model.GetAllCategory();
            model.Categories = (from r in Categories
                           select new SelectListItem
                           {
                               Value = r.Id.ToString(),
                               Text = r.Name
                           }).ToList();
            //model.ReturnUrl = returnUrl;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(MedicineUpdateModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string fileName = UploadedFile(model);
                model.AddNewMedicine(fileName);
            }
            var Categories = model.GetAllCategory();
            model.Categories = (from r in Categories
                                select new SelectListItem
                                {
                                    Value = r.Id.ToString(),
                                    Text = r.Name
                                }).ToList();
            return View(model);
        }
        private string UploadedFile(MedicineUpdateModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "admin\\img\\");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.Name+".jpg";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult GetMedicines()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new MedicineViewModel();
            var data = model.GetMedicines(tableModel);
            return Json(data);
        }
    }
}
