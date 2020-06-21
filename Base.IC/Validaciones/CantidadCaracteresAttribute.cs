namespace Base.IC.Validaciones
{
    using Base.IC.RecursosTexto;
    using System.ComponentModel.DataAnnotations;

    public class CantidadCaracteresAttribute : ValidationAttribute
    {
        private int caracteres;
        public CantidadCaracteresAttribute(int caracteres)
        {
            this.caracteres = caracteres;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var catidadCaracteres = value.ToString().Length;

            if (catidadCaracteres >= caracteres)
            {
                return new ValidationResult(MensajeValidaciones.CantidadCaracteres);
            }

            return ValidationResult.Success;
        }
    }
}