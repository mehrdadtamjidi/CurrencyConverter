using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CurrencyConverter.Core.ViewModels.CurrencyConverter
{
    public class CurrencyConverterViewModel
    {
        public int Id { get; set; }
        public int FromCurrency { get; set; }
        public string FromCurrencyName { get; set; }
        public int ToCurrency { get; set; }
        public string ToCurrencyName { get; set; }
        public decimal Rate { get; set; }
    }

    public class LoadFormCurrencyConverterViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "FromCurrency")]
        public int FromCurrencyId { get; set; }
        public List<SelectListItem> FromCurrency { get; set; }

        [Display(Name = "ToCurrency")]
        public int ToCurrencyId { get; set; }
        public List<SelectListItem> ToCurrency { get; set; }

        public decimal Amount { get; set; }
    }
    public class DataFormCurrencyConverterViewModel
    {
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Amount { get; set; }
    }

    public class ResultConvertViewModel
    {
        public decimal FinalAmount { get; set; }
        public string Path { get; set; }
    }
}
