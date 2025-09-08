using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo1.CustomValidations
{
    [AttributeUsage(AttributeTargets.Property , AllowMultiple = false)]
    public sealed class MinageAttribute: ValidationAttribute
    {
        public int Age { get; }

        public MinageAttribute(int age)
        {
            Age = age;
            ErrorMessage = $"Minimum Age is {age}";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null) return ValidationResult.Success;

            if(value is not DateTime dob)
            return new ValidationResult("MinAge can be used on DateTime properties only");

            var today = DateTime.Today;
            var minBirthDate=today.AddYears(-Age);

            if(dob> minBirthDate)
            {
                var err= ErrorMessage ?? $"Must be at least {Age} years old";
                return new ValidationResult(err, new[] { validationContext.MemberName! });
            }
            return ValidationResult.Success;
        }
    }
}
