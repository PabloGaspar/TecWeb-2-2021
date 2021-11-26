using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class PlayerModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public string Position { get; set; }
        public float? Salary { get; set; }
        public long TeamId { get; set; }
    }
}
