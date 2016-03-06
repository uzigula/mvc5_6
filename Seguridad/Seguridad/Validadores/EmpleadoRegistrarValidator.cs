using FluentValidation;
using Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad.Validadores
{
    class EmpleadoRegistrarValidator : AbstractValidator<EmpleadoRegistrar>
    {
        public EmpleadoRegistrarValidator()
        {
            RuleFor(p => p.Descuentos)
                //   (instanciadeEmpleadoregistrar, el valor de la propiedad
                 .Must((empleado, descuento) =>
                {
                    var montoMaximo = empleado.Sueldo * (decimal)0.5;
                    return (descuento <= montoMaximo);
                }).WithMessage("Descuentos no puede Superar el 50% de Sueldo");
        }
    }
}
