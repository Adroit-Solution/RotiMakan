using Microsoft.AspNetCore.Identity;
using RotiMakan.Database;
using RotiMakan.Models;

namespace RotiMakan.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<IdentityModel> userManager;
        private readonly SignInManager<IdentityModel> signInManager;

        public AuthenticateRepository(UserManager<IdentityModel> userManager, SignInManager<IdentityModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            var roleAdded = await userManager.AddToRoleAsync(user, signUpModel.Service);
            return(result.Succeeded && roleAdded.Succeeded) ? IdentityResult.Success : IdentityResult.Failed();
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
