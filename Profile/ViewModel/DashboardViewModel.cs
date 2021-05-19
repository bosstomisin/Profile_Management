using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.ViewModel
{
    public class DashboardViewModel
    {
        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
        public string Qualifications { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string YearStarted { get; set; }
        public string YearEnded { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
