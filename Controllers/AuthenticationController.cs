using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RotiMakan.Models;
using RotiMakan.Repository;

namespace RotiMakan.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticateRepository repository;

        public AuthenticationController(IAuthenticateRepository repository)
        {
            this.repository = repository;
        }
        
        // GET: AuthenticationControllercs
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.SignUp(signUpModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Authentication");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(signUpModel);
        }

        public ActionResult StudentSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentSignUp(StudentSignUp studentSignUp)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.StudentSignUp(studentSignUp);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Authentication");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(studentSignUp);
        }

        // GET: AuthenticationControllercs/Details/5
        public ActionResult Login()
        {
            return View();
        }

        // GET: AuthenticationControllercs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var result = await repository.Login(loginModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt");
                }
            }
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await repository.SignOut();
            return RedirectToAction("Index", "Home");
            
        }
    }
}
