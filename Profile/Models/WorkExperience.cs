using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Models
{
    public class WorkExperience
    {
        [Key]
        public int WorkExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string YearStarted { get; set; }
        public string YearEnded { get; set; }
        [ForeignKey("ProfileId")]
        public int ProfileId { get; set; }
    }
}
