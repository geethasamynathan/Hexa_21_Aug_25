using ModelValidationDemo1.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelValidationDemo1.Models
{
    public enum EmployeeType
    {
        Permanent,
        Contract,
        Intern
    }

    public class Employee : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required"), StringLength(40)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), StringLength(40)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required"),
         EmailAddress(ErrorMessage = "Invalid Email Address"),
         StringLength(120)
        ]
        public string Email { get; set; }


        [Required, StringLength(10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of Birth is required"),
                    DataType(DataType.Date),
                    Display(Name = "Date of Birth"),
                             ]
        [Minage(21, ErrorMessage = "Employee must be at least 21 years old")]
        [PastDate(ErrorMessage = "Date of Birth must be in the past")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfJoining { get; set; }

        [Range(0, 1000000, ErrorMessage = "Salary must be between 0 and 1,000,000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }


        [Required, EnumDataType(typeof(EmployeeType))]
        public EmployeeType EmployeeType { get; set; } 
        public Address Address { get; set; }
        [Required]

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public DateTime? ContractStart { get; set; }
        public DateTime? ContractEnd { get; set; }
    

        public  IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if(DateOfJoining is DateTime doj)
            {
                var minAge= DateOfBirth.AddYears(18).Date;
                if (doj < minAge)
                    yield return new ValidationResult(
                             $"Employee must be at least 18 years old on Date of Joining. Minimum Date of Joining: {minAge:d}",
                                 new[] { nameof(DateOfJoining) });
            }

            //if (ContractStart.HasValue && ContractEnd.HasValue)
            //{
            //    if (ContractEnd <= ContractStart)
            //    {
            //        yield return new ValidationResult(
            //                                   "Contract End date must be greater than Contract Start date",
            //                                                          new[] { nameof(ContractEnd) });
            //    }
            //}

            //if (DateOfBirth > DateTime.Now.AddYears(-18))
            //{
            //    yield return new ValidationResult(
            //                           "Employee must be at least 18 years old.",
            //                                              new[] { nameof(DateOfBirth) });
            //}
        }
    }
}
