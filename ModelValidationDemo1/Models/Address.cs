using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo1.Models
{
    public class Address
    {
        [Required,StringLength(100)]
        public string Line1 { get; set; }= default!;
        [StringLength(100)]
        public string Line2 { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; } = default!;

        [Required, StringLength(50)]
        public string State { get; set; } = default!;

        [Required,RegularExpression("[0-9]{6}", ErrorMessage = "PinCode must be a 6 digit number")]
        public string PinCode { get; set; } = default!;
    }
}
