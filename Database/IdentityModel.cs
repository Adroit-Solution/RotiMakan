using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RotiMakan.Database
{
    public class IdentityModel:IdentityUser
    {
        public string Name { get; set; }
        public string Owner { get; set; } = "Individual";
        public string Address { get; set; }
    }
}
