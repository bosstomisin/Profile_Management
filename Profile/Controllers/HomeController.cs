using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Profile.Data;
using Profile.Models;
using System.Diagnostics;
using System.Linq;

namespace Profile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfileDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ProfileDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public IActionResult Index(string Message = null)
        {
            //ViewBag.Message = Message;

            var objList = _db.Profiles.Include(x => x.Address).Include(x => x.WorkExperience).FirstOrDefault();
            return View(objList);
        }





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
