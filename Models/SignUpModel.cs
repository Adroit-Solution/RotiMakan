using System.ComponentModel.DataAnnotations;

namespace RotiMakan.Models
{
    public class SignUpModel
    {
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(10)]
        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Required]
        [Display(Name ="Service Providing")]
        public string Service { get; set; }
    }
}
