using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class TeamModel
    {
        public long? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? FundationDate { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Error {0} City name is invalid it should be at most {1} and at least {2}.", MinimumLength = 2)]
        public string City { get; set; }
        public string DTName { get; set; }
        public string ImagePath { get; set; }
    }
}
