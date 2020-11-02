using System;

namespace Countries.Shared.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCool { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime BestDayToVisit { get; set; }
        public int CurrencyId { get; set; }
    }
}
