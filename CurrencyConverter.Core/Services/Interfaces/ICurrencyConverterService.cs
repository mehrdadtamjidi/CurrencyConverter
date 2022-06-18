using CurrencyConverter.Core.ViewModels.CurrencyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Services.Interfaces
{
    public interface ICurrencyConverterService
    {
        LoadFormCurrencyConverterViewModel GetDataForm();

        /// <summary>
        /// Converts the specified amount to the desired currency.
        /// </summary>
        ResultConvertViewModel Convert(DataFormCurrencyConverterViewModel Model);
    }
}
