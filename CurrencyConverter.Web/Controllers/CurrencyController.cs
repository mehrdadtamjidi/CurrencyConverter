using CurrencyConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.ViewModels.Currency;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Web.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyService _Currency;
        public CurrencyController(ICurrencyService Currency)
        {
            _Currency = Currency;
        }
        public IActionResult Index()
        {
            var currencylist = _Currency.GetListCurrencies();
            return View(currencylist);
        }

        public IActionResult Add()
        {
            return PartialView("~/Views/Currency/Partial/_Add.cshtml");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(DataFormCurrencyViewModel Model)
        {
            var result = _Currency.Add(Model);
            return Json(new { status = result });
        }

        public IActionResult Edit(int Id)
        {
            var currency = _Currency.GetDataById(Id);
            return PartialView("~/Views/Currency/Partial/_Edit.cshtml", currency);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(DataFormCurrencyViewModel Model)
        {
            var result = _Currency.Edit(Model);
            return Json(new { status = result });
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var result = _Currency.Delete(Id);
            return Json(new { Status = result });
        }

    }
}
