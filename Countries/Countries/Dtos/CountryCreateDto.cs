using System.ComponentModel.DataAnnotations;

namespace Countries.Dtos
{
    public class CountryCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Elcampo Nombre deber tener un maximo de 20 carácteres")]
        public string Name { get; set; }
        public bool IsCool { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Descripción es Obligatorio")]
        [MaxLength(500, ErrorMessage = "Elcampo Descripción deber tener un maximo de 500 carácteres")]
        public string Description { get; set; }
    }
}
