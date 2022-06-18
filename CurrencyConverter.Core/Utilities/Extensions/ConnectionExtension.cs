using CurrencyConverter.DataLayer.Entities;
using CurrencyConverter.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Core.Utilities.Extensions
{
    public static class ConnectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<CurrencyConverterDbContext>(options =>
            {
                var connectionString = "ConnectionStrings:CurrencyConverterConnection";
                options.UseSqlServer(configuration[connectionString]);
            });

            return service;
        }
    }
}
