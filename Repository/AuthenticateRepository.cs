using Microsoft.AspNetCore.Identity;
using RotiMakan.Database;
using RotiMakan.Models;

namespace RotiMakan.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<IdentityModel> userManager;
        private readonly SignInManager<IdentityModel> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext context;

        public AuthenticateRepository(UserManager<IdentityModel> userManager, SignInManager<IdentityModel> signInManager,RoleManager<IdentityRole> roleManager,AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        public async Task<IdentityResult> SignUp(SignUpModel signUpModel)
        {
            IdentityModel user = new IdentityModel()
            {
                Name = signUpModel.Name,
                UserName = signUpModel.Email,
                Email = signUpModel.Email,
                PhoneNumber = signUpModel.Phone,
                Address = signUpModel.Address,
                Owner = signUpModel.OwnerName
            };

            var result = await userManager.CreateAsync(user, signUpModel.Password);
            if (result.Succeeded)
            {
                IdentityResult roleAdded;
                if (roleManager.RoleExistsAsync(signUpModel.Service).Result)
                {
                    roleAdded = await userManager.AddToRoleAsync(user, signUpModel.Service);
                }
                else
                {
                    await roleManager.CreateAsync(new IdentityRole(signUpModel.Service));
                    roleAdded = await userManager.AddToRoleAsync(user, signUpModel.Service);
                }
                if (roleAdded.Succeeded)
                {
                    return result;
                }
                else
                {
                    return roleAdded;
                }
            }
            else
            {
                return result;
            }

        }

        public async Task<SignInResult> Login(LoginModel loginModel)
        {
            var result = await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.Remember, false);
            return result;
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> StudentSignUp(StudentSignUp studentSignUp)
        {
            IdentityModel user = new IdentityModel()
            {
                Name = studentSignUp.Name,
                UserName = studentSignUp.Email,
                Email = studentSignUp.Email,
                PhoneNumber = studentSignUp.Phone,
                Address = "Student",
                Owner = "Student"
            };

            var result = await userManager.CreateAsync(user, studentSignUp.Password);
            return result;
        }
    }
}
