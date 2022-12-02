using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RotiMakan.Database;
using RotiMakan.Models;

namespace RotiMakan.Repository
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly UserManager<IdentityModel> userManager;
        private readonly SignInManager<IdentityModel> signInManager;

        public DetailsRepository(UserManager<IdentityModel> userManager, SignInManager<IdentityModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<List<DetailsModel>> ShowDetails()
        {
            var details = userManager.Users.ToList().Where(a => a.Owner != "Student");
            var toReturn = new List<DetailsModel>();
            foreach (var item in details)
            {
                var user = new DetailsModel
                {
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    OwnerName = item.Owner,
                    Phone = item.PhoneNumber,
                    Service = (await userManager.GetRolesAsync(item)).FirstOrDefault()
                };
                toReturn.Add(user);
            }
            return toReturn;
        }
    }
}
