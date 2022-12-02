using Microsoft.AspNetCore.Identity;
using RotiMakan.Models;

namespace RotiMakan.Repository
{
    public interface IAuthenticateRepository
    {
        Task<SignInResult> Login(LoginModel loginModel);
        Task SignOut();
        Task<IdentityResult> SignUp(SignUpModel signUpModel);
        Task<IdentityResult> StudentSignUp(StudentSignUp studentSignUp);
    }
}