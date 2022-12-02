using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace RotiMakan.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool Remember { get; set; }
    }
}
