using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NecessaryDrugs.Web.Areas.Admin.Models;

namespace NecessaryDrugs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockController : Controller
    {

        public IActionResult Index()
        {
            var model = new StockViewModel();
            return View(model.GetStocks());
        }
        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            var model = new StockUpdateModel();

            if (id == 0)
                return View(model);
            else
            {
                model.Load(id);
                return View(model);
            }
                //{
                //    var transactionModel = await _context.Transactions.FindAsync(id);
                //    if (transactionModel == null)
                //    {
                //        return NotFound();
                //    }
                //    return View(transactionModel);
                
        }
        [HttpPost]
        public IActionResult AddOrEdit(int id, /*[Bind("Id,MedicineId,Quantity,TotalPrice,Description")]*/ StockUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    model.AddStock();

                }
                //Update
                else
                {
                    model.UpdateStock(id);
                }
                return Json(new { isValid = true, html = Helper<StockController>.RenderRazorViewToString(this, "_ViewAll", model.GetAllStocks()) });
            }
            return Json(new { isValid = false, html = Helper<StockController>.RenderRazorViewToString(this, "AddOrEdit", model) });
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = new StockUpdateModel();

            model.Delete(id);
            return Json(new { html = Helper<StockController>.RenderRazorViewToString(this, "_ViewAll", model.GetAllStocks()) });
        }
    }
}
