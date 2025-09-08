using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo1.CustomValidations
{
    public sealed class PastDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is DateTime dt)
                return dt < DateTime.Now;
            return true;
            
        }
    }
}
