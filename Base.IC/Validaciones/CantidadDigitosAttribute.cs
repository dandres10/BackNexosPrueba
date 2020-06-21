namespace Base.IC.Validaciones
{
    using Base.IC.RecursosTexto;
    using System.ComponentModel.DataAnnotations;

    public class CantidadDigitosAttribute : ValidationAttribute
    {
        private int numeroDigitos;
        public CantidadDigitosAttribute(int numeroDigitos)
        {
            this.numeroDigitos = numeroDigitos;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var catidadDigitos = value.ToString().Length;

            if (catidadDigitos >= numeroDigitos)
            {
                return new ValidationResult(MensajeValidaciones.CantidadDigitos);
            }

            return ValidationResult.Success;
        }
    }
}