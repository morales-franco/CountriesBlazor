using Countries.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Countries.Data
{
    /*
     * Clase encargada de popular la DB con información base.
     * Ejemplo: las Currencies soportadas por el sistema son: Peso ARG | Soles | USD.
     * No existira un modulo de monedas.
     */
    public static class ApplicationDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this ApplicationDbContext context)
        {
            TryInitCurrencies(context);
        }

        private static void TryInitCurrencies(ApplicationDbContext context)
        {
            if (context.Currencies.Any())
                return;

            var currencies = new List<Currency>()
            {
                new Currency()
                {
                    Name = "Peso ARG"
                },
                new Currency()
                {
                    Name = "Sol PERU"
                },
                new Currency()
                {
                    Name = "DOLAR USD"
                }
            };

            context.Currencies.AddRange(currencies);
            context.SaveChanges();
        }
    }
}
