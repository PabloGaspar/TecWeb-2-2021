using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public string Position { get; set; }
        public float? Salary { get; set; }
        [ForeignKey("TeamId")]
        public virtual TeamEntity Team { get; set; }
    }
}
