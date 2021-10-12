using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameAPI.Data.Entities
{
    public class CompanyEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime? FundationDate { get; set; }
        public string CEO { get; set; }
        public virtual ICollection<VideoGameEntity> Videogames { get; set; }
    }
}
