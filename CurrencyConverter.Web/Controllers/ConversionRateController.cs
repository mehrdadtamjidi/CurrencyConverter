using ConversionRateConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.ViewModels.ConversionRate;
using Microsoft.AspNetCore.Mvc;

namespace ConversionRateConverter.Web.Controllers
{
    public class ConversionRateController : Controller
    {
        private IConversionRateService _ConversionRate;
        public ConversionRateController(IConversionRateService ConversionRate)
        {
            _ConversionRate = ConversionRate;
        }
        public IActionResult Index()
        {
            var ConversionRatelist = _ConversionRate.GetListCurrencies();
            return View(ConversionRatelist);
        }

        public IActionResult Add()
        {
            return PartialView("~/Views/ConversionRate/Partial/_Add.cshtml", _ConversionRate.GetDataById(0));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(DataFormConversionRateViewModel Model)
        {
            var result = _ConversionRate.Add(Model);
            return Json(new { status = result });
        }

        public IActionResult Edit(int Id)
        {
            var ConversionRate = _ConversionRate.GetDataById(Id);
            return PartialView("~/Views/ConversionRate/Partial/_Edit.cshtml", ConversionRate);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(DataFormConversionRateViewModel Model)
        {
            var result = _ConversionRate.Edit(Model);
            return Json(new { status = result });
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var result = _ConversionRate.Delete(Id);
            return Json(new { Status = result });
        }
    }
}
