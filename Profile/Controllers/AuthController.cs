using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Profile.Models;
using Profile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Address = new Address
                {
                    Country = model.Country,
                    State = model.State,
                    City = model.City,
                    Street = model.Street,
                };

                var WorkExperience = new WorkExperience
                {
                    CompanyName = model.CompanyName,
                    JobDescription = model.JobDescription,
                    JobTitle = model.JobTitle,
                    YearEnded = model.YearEnded,
                    YearStarted = model.YearStarted,
                };

                var user = new ProfileDetails
                {
                    UserName = model.Email,
                    Email = model.Email, 
                    PhoneNumber = model.PhoneNumber,
                    Profession = model.Profession,
                    Qualifications = model.Qualifications,
                    LinkedInUrl = model.LinkedInUrl,
                    GitHubUrl = model.GitHubUrl,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                user.Addresses.Add(Address);
                user.WorkExperiences.Add(WorkExperience);


                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password,false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
