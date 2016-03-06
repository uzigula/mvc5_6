using Seguridad.Anotaciones;
using System.ComponentModel.DataAnnotations;

namespace Seguridad.Models
{
    public class EmpleadoRegistrar
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Cargo { get; set; }

        [Required]
        public decimal Sueldo { get; set; }

        //[MaximoDescuento("Sueldo",50)]
        public decimal Descuentos { get; set; }
    }
}
