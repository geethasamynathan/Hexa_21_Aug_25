using ModelValidationDemo1.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo1.Models
{
    public class Department
    {
       //[Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        //[MaxLength(30, ErrorMessage = "Department Name cannot exceed 50 characters")] //columnsize validation
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Department Name must be between 3 and 30 characters")]
        [ProhibitedWords("test","dummy")]
        public string Name { get; set; } = default!;

        [StringLength(30, ErrorMessage = "Location cannot exceed 30 characters")]
        public string  Location { get; set; }

        public ICollection<Employee>  Employees { get; set; }
    }
}
