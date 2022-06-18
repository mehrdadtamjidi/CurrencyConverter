using ConversionRateConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.ViewModels.ConversionRate;
using CurrencyConverter.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CurrencyConverter.Core.Services.Implementations
{
    public class ConversionRateService : IConversionRateService
    {
        private CurrencyConverterDbContext _context;

        public ConversionRateService(CurrencyConverterDbContext context)
        {
            _context = context;
        }

        public bool Add(DataFormConversionRateViewModel Form)
        {
            try
            {
                var ConversionRate = new DataLayer.Entities.ConversionRate
                {
                    FromCurrency = Form.FromCurrencyId,
                    Rate = Form.Rate,
                    ToCurrency = Form.ToCurrencyId
                };
                _context.ConversionRates.Add(ConversionRate);
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
                var ConversionRate = _context.ConversionRates.First(v => v.Id == Id);
                _context.ConversionRates.Remove(ConversionRate);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool Edit(DataFormConversionRateViewModel Form)
        {
            try
            {
                var conversionRate = _context.ConversionRates.Single(b => b.Id == Form.Id);
                conversionRate.FromCurrency = Form.FromCurrencyId;
                conversionRate.ToCurrency = Form.ToCurrencyId;
                conversionRate.Rate = Form.Rate;
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public LoadFormConversionRateViewModel GetDataById(int Id = 0)
        {
           
            if (Id == 0)
            {
                LoadFormConversionRateViewModel _LoadFormConversionRateViewModelVM = new LoadFormConversionRateViewModel();
                _LoadFormConversionRateViewModelVM.FromCurrency = _context.Currencies.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList();

                _LoadFormConversionRateViewModelVM.ToCurrency = _context.Currencies.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList();
                return _LoadFormConversionRateViewModelVM;
            }
            else
            {
                var conversionRates = _context.ConversionRates.Where(b => b.Id == Id).Select(b => new LoadFormConversionRateViewModel
                {
                    Id = b.Id,
                    FromCurrencyId = b.FromCurrency,
                    ToCurrencyId = b.ToCurrency,
                    Rate = b.Rate
                }).FirstOrDefault();

                conversionRates.FromCurrency = _context.Currencies.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList();

                conversionRates.ToCurrency = _context.Currencies.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList();
                return conversionRates;
            }
       
        }

        public List<CurrencyConverterViewModel> GetListCurrencies()
        {
            var conversionRates = _context.ConversionRates.Select(b => new CurrencyConverterViewModel
            {
                Id = b.Id,
                Rate = b.Rate,
                FromCurrency = b.FromCurrency,
                ToCurrency = b.ToCurrency,
                FromCurrencyName = _context.Currencies.Where(x => x.Id == b.FromCurrency).Single().Title,
                ToCurrencyName = _context.Currencies.Where(x => x.Id == b.ToCurrency).Single().Title
            }).ToList();
            return conversionRates;
        }
    }
}
