using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Profile.Data;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfileDbContext _db;
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           // _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            //var objList = _db.Profiles.Include(x => x.Addresses).Include(x => x.WorkExperiences).FirstOrDefault();

            return View();
        }

        [HttpPost]
       // public IActionResult Index(ProfileDetails profile)
        //{
            //if (ModelState.IsValid)
            //{
            //    var objList = _db.Profiles.Include(x => x.Addresses).Include(x => x.WorkExperiences).FirstOrDefault();

            //    objList.FirstName = profile.FirstName;
            //    objList.LastName = profile.LastName;
            //    objList.Profession = profile.Profession;
            //    _db.SaveChanges();
            //    return RedirectToAction()
            //}
            //return View(objList);
           // return View();
            
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
