using ConversionRateConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.Services.Implementations;
using CurrencyConverter.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace CurrencyConverter.Core.Utilities.Common
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer
            service.AddScoped<IConversionRateService, ConversionRateService>();
            service.AddScoped<ICurrencyService, CurrencyService>();
            service.AddScoped<ICurrencyConverterService, CurrencyConverterService>();
        }
    }
}
