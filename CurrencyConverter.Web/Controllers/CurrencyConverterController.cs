
using CurrencyConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.ViewModels.CurrencyConverter;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Web.Controllers
{
    public class CurrencyConverterController : Controller
    {
        private ICurrencyConverterService _CurrencyConverter;
        public CurrencyConverterController(ICurrencyConverterService CurrencyConverter)
        {
            _CurrencyConverter = CurrencyConverter;
        }

        public IActionResult Index()
        {
            var CurrencyConverter = _CurrencyConverter.GetDataForm();
            return View(CurrencyConverter);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Convert(DataFormCurrencyConverterViewModel Model)
        {
            var res = _CurrencyConverter.Convert(Model);
            return Json(res);
        }
    }
}
