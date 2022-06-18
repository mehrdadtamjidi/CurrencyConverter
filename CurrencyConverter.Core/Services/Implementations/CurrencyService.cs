using CurrencyConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.ViewModels.Currency;
using CurrencyConverter.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private CurrencyConverterDbContext _context;

        public CurrencyService(CurrencyConverterDbContext context)
        {
            _context = context;
        }
        public bool Add(DataFormCurrencyViewModel Form)
        {
            try
            {
                var Currency = new DataLayer.Entities.Currency
                {
                    Title = Form.Title,
                };
                _context.Currencies.Add(Currency);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var Currency = _context.Currencies.First(v => v.Id == Id);
                _context.Currencies.Remove(Currency);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool Edit(DataFormCurrencyViewModel Form)
        {
            try
            {
                var currency = _context.Currencies.Single(b => b.Id == Form.Id);
                currency.Title = Form.Title;
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public LoadFormCurrencyViewModel GetDataById(int Id)
        {
            var currencies = _context.Currencies.Where(b => b.Id == Id).Select(b => new LoadFormCurrencyViewModel
            {
                Id = b.Id,
                Title = b.Title
            }).FirstOrDefault();

            return currencies;
        }
        public List<CurrencyViewModel> GetListCurrencies()
        {
            var currencies = _context.Currencies.Select(b => new CurrencyViewModel
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();
            return currencies;
        }
    }
}
