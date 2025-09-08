using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo1.CustomValidations
{
    public class ProhibitedWordsAttribute: ValidationAttribute
    {
        private readonly string[] _words;
        public ProhibitedWordsAttribute(params string[] words) => _words = words ?? [];
       
        public override bool IsValid(object? value)
        {
            if(value is string s)
            {
                foreach(var w in _words)
                    if(s.Contains(w, StringComparison.OrdinalIgnoreCase))
                        return  false;
            }
            return true;
        }
    }
}
