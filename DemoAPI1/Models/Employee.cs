using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoAPI1.Models
{
    
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required ,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        public string Location { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; } //Navigation property
    }
}
