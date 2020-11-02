using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NecessaryDrugs.Web.Areas.Admin.Models;
using NecessaryDrugs.Web.Areas.Client.Models;

namespace NecessaryDrugs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new OrderModel();
            return View(await model.GetAllOrders());
        }

        public IActionResult Delete(int id)
        {
            var model = new OrderModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
