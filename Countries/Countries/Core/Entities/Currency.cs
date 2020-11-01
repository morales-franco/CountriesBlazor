using System.Collections.Generic;

namespace Countries.Core.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //1 moneda puede perteneces a varios paises
        //Relación 1-M  entre currency y countries
        public List<Country> Countries { get; set; }
    }
}
