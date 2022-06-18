using System;
using System.Collections.Generic;

#nullable disable

namespace CurrencyConverter.DataLayer.Entities
{
    public partial class Currency
    {
        public Currency()
        {
            ConversionRateFromCurrencyNavigations = new HashSet<ConversionRate>();
            ConversionRateToCurrencyNavigations = new HashSet<ConversionRate>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ConversionRate> ConversionRateFromCurrencyNavigations { get; set; }
        public virtual ICollection<ConversionRate> ConversionRateToCurrencyNavigations { get; set; }
    }
}
