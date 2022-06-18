using System;
using System.Collections.Generic;

#nullable disable

namespace CurrencyConverter.DataLayer.Entities
{
    public partial class ConversionRate
    {
        public int Id { get; set; }
        public int FromCurrency { get; set; }
        public int ToCurrency { get; set; }
        public decimal Rate { get; set; }

        public virtual Currency FromCurrencyNavigation { get; set; }
        public virtual Currency ToCurrencyNavigation { get; set; }
    }
}
