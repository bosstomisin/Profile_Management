using Microsoft.AspNetCore.Mvc;
using Profile.Data;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Controllers
{
    public class ContactController : Controller
    {
        private readonly ProfileDbContext _db;
        public ContactController(ProfileDbContext db)
        {
            _db = db;
        }       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Contact obj )
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
            
    }

    }
}
  