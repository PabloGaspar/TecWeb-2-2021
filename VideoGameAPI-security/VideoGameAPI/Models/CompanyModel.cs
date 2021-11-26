using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameAPI.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "Error {0} the max leng of the company name is{1} min lenght is {2}", MinimumLength = 2)]
        public string Country { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FundationDate { get; set; }
        public string CEO { get; set; }

        public IEnumerable<VideogameModel> Videogames { get; set; }
    }
}
