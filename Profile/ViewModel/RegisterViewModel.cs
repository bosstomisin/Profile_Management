using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
        public string Qualifications { get; set; }
        [DisplayName("LinkedIn Url")]
        public string LinkedInUrl { get; set; }
        [DisplayName("GitHub Url")]
        public string GitHubUrl { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
        [DisplayName("Job Description")]
        public string JobDescription { get; set; }
        [DisplayName("Year Started")]
        public string YearStarted { get; set; }
        [DisplayName("Year Ended")]
        public string YearEnded { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
