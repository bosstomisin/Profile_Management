using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profile.Data;
using Profile.Models;
using Profile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ProfileDbContext _db;
        private readonly UserManager<ProfileDetails> _userManager;
        private readonly SignInManager<ProfileDetails> _signInManager;

        public DashboardController(ProfileDbContext db, UserManager<ProfileDetails> userManager, SignInManager<ProfileDetails> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var Obj = _db.Profiles.Include(x => x.Address).Include(x => x.WorkExperience).FirstOrDefault();
            DashboardViewModel obj = new DashboardViewModel()
            {
                Id = Obj.Id,
                FirstName = Obj.FirstName,
                LastName = Obj.LastName,
                Email = Obj.Email,
                PhoneNumber = Obj.PhoneNumber,
                Profession = Obj.Profession,
                Qualifications = Obj.Qualifications,
                Street = Obj.Address.Street,
                City = Obj.Address.City,
                State = Obj.Address.State,
                Country = Obj.Address.Country,
                GitHubUrl = Obj.GitHubUrl,
                LinkedInUrl = Obj.LinkedInUrl,
                CompanyName = Obj.WorkExperience.CompanyName,
                JobTitle = Obj.WorkExperience.JobTitle,
                JobDescription = Obj.WorkExperience.JobDescription,
                YearStarted = Obj.WorkExperience.YearStarted,
                YearEnded = Obj.WorkExperience.YearEnded
            };
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Index(DashboardViewModel model)
        {
            var Obj = _db.Profiles.Include(x => x.Address).Include(x => x.WorkExperience).FirstOrDefault();
            Obj.Id = model.Id;
            Obj.Address.ProfileDetailsId = model.Id;
            Obj.FirstName = model.FirstName;
            Obj.LastName = model.LastName;
            Obj.Email = model.Email;
            Obj.PhoneNumber = model.PhoneNumber;
            Obj.Profession = model.Profession;
            Obj.Qualifications = model.Qualifications;
            Obj.Address.Street = model.Street;
            Obj.Address.City = model.City; 
            Obj.Address.Country = model.Country;
            Obj.GitHubUrl = model.GitHubUrl;
            Obj.LinkedInUrl = model.LinkedInUrl;
            Obj.WorkExperience.CompanyName = model.CompanyName;
            Obj.WorkExperience.JobTitle = model.JobTitle;
            Obj.WorkExperience.JobDescription = model.JobDescription;
            Obj.WorkExperience.YearStarted = model.YearStarted;
            Obj.WorkExperience.YearEnded = model.YearStarted;


            var result = await _userManager.UpdateAsync(Obj);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(Obj, isPersistent: false);

                return RedirectToAction("index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(model);


        }
    }
}
