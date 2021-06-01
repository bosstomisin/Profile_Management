using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Models
{
    public class Address
    {
        public Address()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ProfileDetailsId { get; set; }
        [ForeignKey("ProfileDetailsId")]
        public ProfileDetails ProfileDetails  { get; set; }
    }
}
