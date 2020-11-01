using System;
using System.ComponentModel.DataAnnotations;

namespace Countries.Dtos
{
    public class CountryUpdateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Elcampo Nombre deber tener un maximo de 20 carácteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Es cool es Obligatorio")]
        public bool IsCool { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Descripción es Obligatorio")]
        [MaxLength(500, ErrorMessage = "Elcampo Descripción deber tener un maximo de 500 carácteres")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Mejor día para visitar es Obligatorio")]
        public DateTime BestDayToVisit { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Moneda es Obligatorio")]
        public int CurrencyId { get; set; }
    }
}
