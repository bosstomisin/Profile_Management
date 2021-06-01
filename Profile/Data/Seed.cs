using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Data
{
    public static class Seed
    {
        private const string email = "tadereti@gmail.com";
        private const string password = "Adereti1!";

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ProfileDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<ProfileDetails>>();

            var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();

            if(user == null)
            {
                user = new ProfileDetails
                {
                    FirstName = "Adereti", 
                    LastName = "Tomisin", 
                    Email = email, 
                    PhoneNumber = "08169392110", 
                    Qualifications = "B.Tech in Comp. Sc.", 
                    Profession = "Software Engineer", 
                    GitHubUrl = "https://github.com/bosstomisin", 
                    LinkedInUrl = "https://www.linkedin.com/in/adereti-tomisin-b778661b7",
                    UserName = email

                };
                var addr = new Address { Street = "7, Asajon way", City = "Sangotedo", State = "Lagos", Country = "Nigeria", ProfileDetailsId = user.Id };
                var workeperience = new WorkExperience { CompanyName = "Decagon Institute",
                    JobTitle = "Software Engineer", JobDescription = ".Net Software Developer", 
                    YearEnded = new DateTime(2018,04,04), YearStarted = new DateTime(2019, 03, 03), ProfileDetailsId = user.Id };

                user.Address = addr;
                user.WorkExperience = workeperience;

                userManager.CreateAsync(user, password).GetAwaiter().GetResult();
            }
        }
    }
}
