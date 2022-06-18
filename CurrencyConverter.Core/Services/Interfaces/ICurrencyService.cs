using CurrencyConverter.Core.ViewModels.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Services.Interfaces
{
    public interface ICurrencyService
    {
        LoadFormCurrencyViewModel GetDataById(int Id);
        bool Add(DataFormCurrencyViewModel Form);
        bool Edit(DataFormCurrencyViewModel Form);
        List<CurrencyViewModel> GetListCurrencies();
        bool Delete(int Id);
    }
}
