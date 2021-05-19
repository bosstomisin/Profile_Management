using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profile.Data;
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

        public DashboardController(ProfileDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Obj = _db.Profiles.Include(x => x.Addresses).Include(x => x.WorkExperiences).FirstOrDefault();
            DashboardViewModel obj = new DashboardViewModel()
            {
                FirstName=Obj.FirstName,
            };
            return View(Obj);
        }
    }
}
