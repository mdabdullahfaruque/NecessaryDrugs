using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NecessaryDrugs.Web.Areas.Client.Models;

namespace NecessaryDrugs.Web.Areas.Client.Controllers
{
    [Area("Client")]
    public class MedicineController : Controller
    {
        public IActionResult Index()
        {
            var model = new MedicineViewModel();
            return View(model.GetMedicines());
        }
        public IActionResult Details(int id)
        {
            var model = new MedicineViewModel();
            model.GetDetails(id);
            return View(model);
        }
    }
}
