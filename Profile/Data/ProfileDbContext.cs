using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Profile.Models;

namespace Profile.Data
{
    public class ProfileDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly DbContextOptions _options;

        public ProfileDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<ProfileDetails> Profiles { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
