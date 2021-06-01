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
        private readonly UserManager<ProfileDetails> _userManager;
        private readonly SignInManager<ProfileDetails> _signInManager;

        public AuthController(UserManager<ProfileDetails> userManager,
                                      SignInManager<ProfileDetails> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
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
                    Address = new Address {
                        Street = model.Street,
                        City = model.City,
                        State = model.State,
                        Country = model.Country
                    },
                    WorkExperience = new WorkExperience {
                        CompanyName = model.CompanyName,
                        JobTitle = model.JobTitle,
                        JobDescription = model.JobDescription,
                        YearStarted = model.YearStarted,
                        YearEnded = model.YearEnded
                    },
                };
               
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //ViewBag.Message = "Congratulations! Tomisin";

                    return RedirectToAction("Index", "Home", new { Message = ViewBag.Message });
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
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

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
