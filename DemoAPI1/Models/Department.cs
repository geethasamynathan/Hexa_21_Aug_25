using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoAPI1.Models
{
    public class Department
    {
        public int Id { get; set; } //primary key
       
        public string? DepartmentName { get; set; }
        public string? Location { get; set; }
        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; } //Navigation property


    }
}
