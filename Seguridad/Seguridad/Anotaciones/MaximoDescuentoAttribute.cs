using System;
using System.ComponentModel.DataAnnotations;

namespace Seguridad.Anotaciones
{
    public class MaximoDescuentoAttribute : ValidationAttribute
    {
        private readonly double MaximoPorcentaje;
        private readonly string PropiedadRelativa;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propiedadRelativa">Con la se comparara el limite a descontar</param>
        /// <param name="maximoPorcentaje">maximo porcentaje de la propiedad relativa a aceptar</param>
        public MaximoDescuentoAttribute(string propiedadRelativa, double maximoPorcentaje)
        {
            this.PropiedadRelativa = propiedadRelativa;
            this.MaximoPorcentaje = maximoPorcentaje;
        }

        /// <summary>
        /// Devuelve el mensaje de Error de validacion
        /// </summary>
        /// <param name="name">Es el nombre de la Propieda a la que se aplica el atributo</param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            return $"{name} no puede exceder del {MaximoPorcentaje}% de {PropiedadRelativa}";
        }
        /// <summary>
        /// Para validaciones que dependen solo del valor de la propiedad
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //public override bool IsValid(object value)
        //{
        //    return base.IsValid(value);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">El valor de la Propiedad a la que se aplico el atributo</param>
        /// <param name="validationContext">La instancia del objecto que se esta evaluando</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double monto = Convert.ToDouble(value); // obtengo el valor de la propiedad

            var propiedadRelativa = validationContext
                .ObjectType
                .GetProperty(PropiedadRelativa);

            if (propiedadRelativa!=null)
            {
                double montoBase = Convert.ToDouble(propiedadRelativa
                                    .GetValue(
                                    validationContext.ObjectInstance
                                    , null));

                double calculado = montoBase * MaximoPorcentaje / 100;
                if (monto <= calculado) return ValidationResult.Success;
            }

            return new 
                ValidationResult(
                FormatErrorMessage(validationContext.DisplayName)
                );
        }

    }
}