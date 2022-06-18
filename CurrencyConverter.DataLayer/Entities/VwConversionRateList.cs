using System;
using System.Collections.Generic;

#nullable disable

namespace CurrencyConverter.DataLayer.Entities
{
    public partial class VwConversionRateList
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal ConversionRate { get; set; }
    }
}
