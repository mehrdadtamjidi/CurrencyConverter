using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CurrencyConverter.Core.ViewModels.ConversionRate
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

    public class LoadFormConversionRateViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "FromCurrency")]
        [Required(ErrorMessage = "Please enter {0}")]
        public int FromCurrencyId { get; set; }
        public List<SelectListItem> FromCurrency { get; set; }

        [Display(Name = "ToCurrency")]
        [Required(ErrorMessage = "Please enter {0}")]
        public int ToCurrencyId { get; set; }
        public List<SelectListItem> ToCurrency { get; set; }

        [Display(Name = "ConversionRate")]
        [Required(ErrorMessage = "Please enter {0}")]
        public decimal Rate { get; set; }
    }
    public class DataFormConversionRateViewModel
    {
        public int Id { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Rate { get; set; }
    }
}
