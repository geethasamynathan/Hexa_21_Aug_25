using System.ComponentModel.DataAnnotations;

namespace DemoAPI1.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
