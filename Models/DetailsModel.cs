using System.ComponentModel.DataAnnotations;

namespace RotiMakan.Models
{
    public class DetailsModel
    {
        public string Name { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Display(Name="Contact Number")]
        public string Phone { get; set; }

        [Display(Name ="Email Address")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Display(Name="Services Providing")]
        public string Service { get; set; }
    }
}
