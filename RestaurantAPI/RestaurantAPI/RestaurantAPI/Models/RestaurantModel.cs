using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Founded { get; set; }
    }
}
