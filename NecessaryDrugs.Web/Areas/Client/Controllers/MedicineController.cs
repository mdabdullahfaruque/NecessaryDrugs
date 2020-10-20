using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NecessaryDrugs.Web.Areas.Client.Models;
using Newtonsoft.Json;
using X.PagedList;

namespace NecessaryDrugs.Web.Areas.Client.Controllers
{
    [Area("Client")]
    public class MedicineController : Controller
    {
        //public IActionResult Index()
        //{
        //    var model = new MedicineViewModel();
        //    return View(model.GetMedicines());
        //}
        

        public IActionResult Index(int? page, string searchString)//Add page parameter
        {
            var model = new MedicineViewModel();
            if (searchString != null)
            {
                TempData["SearchText"] = searchString;
            }
            else
            {
                TempData.Remove("SearchText");
            }
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
            int pageSize = 6; // Get 6 medicines for each requested page.
            var onePageOfStudents = (searchString==null)? model.GetMedicines().ToPagedList(pageNumber, pageSize) 
                    : model.GetFilteredMedicines(searchString).ToPagedList(pageNumber, pageSize); ;
            return View(onePageOfStudents); // Send 6 medicines to the page.
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            return RedirectToAction("Index","Medicine",new { searchString });
        }
    }
}
