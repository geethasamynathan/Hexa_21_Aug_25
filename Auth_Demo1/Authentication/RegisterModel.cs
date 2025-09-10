using System.ComponentModel.DataAnnotations;

namespace Auth_Demo1.Authentication
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        
        public string Role { get; set; }
    }
}
