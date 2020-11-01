using System;

namespace Countries.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCool { get; set; }
        public DateTime BestDayToVisit { get; set; }

        //1 pais tiene una unica moneda.
        //Relación 1-M  entre currency y countries
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }


    }
}
