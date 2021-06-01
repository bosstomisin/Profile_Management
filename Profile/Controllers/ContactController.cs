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
        [HttpGet]
       public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Contact obj)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact { FirstName = obj.FirstName, LastName =obj.LastName, Email= obj.Email,Message = obj.Message };
                _db.Contacts.Add(contact);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }

    }
}
