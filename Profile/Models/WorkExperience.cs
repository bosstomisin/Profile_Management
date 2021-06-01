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
        public WorkExperience()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        
        public string JobDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime YearStarted { get; set; }
        [DataType(DataType.Date)]
        public DateTime YearEnded { get; set; }
        public string ProfileDetailsId { get; set; }
        [ForeignKey("ProfileDetailsId")]
        public ProfileDetails ProfileDetails { get; set; }

    }
}
