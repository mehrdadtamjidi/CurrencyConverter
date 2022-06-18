using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.ViewModels.Currency
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class LoadFormCurrencyViewModel
    {
        [Display(Name = "ID")]
        public long Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string Title { get; set; }
    }
    public class DataFormCurrencyViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
