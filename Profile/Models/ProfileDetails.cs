using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Models
{
    public class ProfileDetails : IdentityUser
    {
        
        //public ProfileDetails()
        //{
        //    WorkExperiences = new List<WorkExperience>();
        //    Addresses = new List<Address>();
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Qualifications { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string Password { get; set; }

        public WorkExperience WorkExperience { get; set; }
        public Address Address { get; set; }
    }
}
